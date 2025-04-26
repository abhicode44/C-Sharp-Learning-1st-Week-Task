using System.Diagnostics;
using Bank_Application.Controllers;
using Bank_Application.Interface.GernralRepository;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.BenificiaryDto;
using Bank_Application.Model.CompanyDto;
using Bank_Application.Model.SalaryDistrubutionDto;
using Bank_Application.Model.TransactionDto;

namespace Bank_Application.Services
{
    public class AdminService : IAdminService
    {   
        IGenericRepository<Admin> repository;
        IGenericRepository<Company> companyRepository;
        IGenericRepository<Benificiary> benificaryRepository;
        IGenericRepository<Transactionn> transactionRepository;
        IGenericRepository<SalaryDistribution> salaryDistributionRepository;
        IAuditService auditService;
        IHttpContextAccessor _httpContextAccessor;
        

        public AdminService(IGenericRepository <Admin> adminRepository , IGenericRepository <Company> companyRepository , IGenericRepository<Benificiary> benificiaryRepository, IGenericRepository<Transactionn> transactionRepository , IGenericRepository<SalaryDistribution> salaryDistributionRepository , IAuditService auditService , IHttpContextAccessor httpContextAccessor )
        {
            this.repository = adminRepository;
            this.companyRepository = companyRepository;
            this.benificaryRepository = benificiaryRepository;
            this.transactionRepository = transactionRepository;
            this.salaryDistributionRepository = salaryDistributionRepository;
            this.auditService = auditService;
            this._httpContextAccessor = httpContextAccessor;
        }


        public string GetUserEmailFromJwt()
        {
            var emailClaim = _httpContextAccessor.HttpContext?.User?.Claims
            .FirstOrDefault(c => c.Type == "EmailId");
            return emailClaim?.Value ?? throw new Exception("User email not found in token.");
        }

        public string GetUserRoleFromJwt()
        {
            var roleClaim = _httpContextAccessor.HttpContext?.User?.Claims
               .FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
            return roleClaim?.Value ?? throw new Exception("User role not found in token.");
        }


        public Admin AddAdmin(AddAdminDto addAdminDto)
        {
            if (repository.GetAll().Any(a => a.AdminEmail == addAdminDto.AdminEmail))
            {
                throw new InvalidOperationException("An admin with this email already exists.");
            }

            var adminEntity = new Admin
            {
                AdminFirstName = addAdminDto.AdminFirstName,
                AdminLastName = addAdminDto.AdminLastName,
                AdminEmail = addAdminDto.AdminEmail,
                AdminPassword = addAdminDto.AdminPassword,
                IsAdminActive = true,
                RoleId =  1 
            };
            repository.Add(adminEntity);

            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();

            string activity = $"Admin {loggedInUserEmail} added new admin: {addAdminDto.AdminEmail}";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return adminEntity;
        }

        

        public Admin updateAdminActivation(int AdminId, AdminActivationDto activationDto)
        {
            var adminEntity = repository.GetById(AdminId);
            if (adminEntity == null)
            {
                throw new KeyNotFoundException($"Admin with ID {AdminId} not found!");
            }

            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();

            string activity = $"{loggedInUserEmail} {(activationDto.IsAdminActive ? "activated" : "deactivated")} admin account: {adminEntity.AdminEmail}";


            adminEntity.IsAdminActive = activationDto.IsAdminActive;
            repository.Update(adminEntity);

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return adminEntity;
        }


        public List<Admin> GetAllAdmin()
        {

            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all admins";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return repository.GetAll();
            
        }

        

        public Company UpdateDocumentVerify(string CompanyEmail, DocumentVerifyDto documentVerifyDto) {
            var companyEntity = companyRepository.GetByEmail(CompanyEmail);
            if (companyEntity == null)
            {
                throw new Exception($" This Company Email Id  {CompanyEmail} not found.");
            }
            companyEntity.IsDocumentVerified = documentVerifyDto.IsDocumentVerified;
            companyEntity.DocumentStatusDesciption = documentVerifyDto.DocumentStatusDesciption;
            companyRepository.Update(companyEntity);

            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();

            string activity = documentVerifyDto.IsDocumentVerified
             ? $"Admin '{loggedInUserEmail}' verified documents for company '{CompanyEmail}'."
            : $"Admin '{loggedInUserEmail}' marked document verification failed for company '{CompanyEmail}'.";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return companyEntity;
        }


        public List<Company> GetAllApprovedCompanies()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Approved Companies ";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return companyRepository.GetAll().Where(c => c.IsDocumentVerified == true).ToList();


        }

        public List<Company> GetAllPendingCompanies()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Pending Companies ";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return companyRepository.GetAll().Where(c => c.IsDocumentVerified == false).ToList();
        }

        public List<Benificiary> GetAllPendingOutBenificiaryBoundCompany()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Pending OutBound Benificiary Companies ";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return benificaryRepository.GetAll().Where(c => c.IsBenificiaryApproved == false).ToList();
        }

       

        public Benificiary VerifyOutBoundCompany(int BenificiaryId, VerifyOutBoundCompanyDto verifyOutBoundCompanyDto)
        {
           var benificiaryEntity = benificaryRepository.GetById(BenificiaryId);
            if (benificiaryEntity == null) 
            {
                throw new Exception($" This Benificiary Id  {BenificiaryId} not found.");
            }
            benificiaryEntity.IsBenificiaryApproved = verifyOutBoundCompanyDto.IsBenificiaryApproved;
            benificaryRepository.Update(benificiaryEntity);
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();


            string activity = verifyOutBoundCompanyDto.IsBenificiaryApproved
                ? $"Admin '{loggedInUserEmail}' approved Out Bound Benificiary with ID '{BenificiaryId}'."
                : $"Admin '{loggedInUserEmail}' rejected Out Bound Benificiary with ID '{BenificiaryId}'.";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return benificiaryEntity;
        }

        public List<Benificiary> GetAllApprovedOutBenificiaryBoundCompany()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Pending OutBound Benificiary Companies. ";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return benificaryRepository.GetAll().Where(c => c.IsBenificiaryApproved == true).ToList();
        }

        public List<Transactionn> GetAllPendingTransactionRequest()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Pending Transactions Request ";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return transactionRepository.GetAll().Where(c => c.IsTransactionApproved == false).ToList();
        }

        public Transactionn VerifyTransactionRequest(int TransactionId, VerifyTransactionDto verifyTransactionDto)
        {
            var transactionEntity = transactionRepository.GetById(TransactionId);   
            if (transactionEntity == null)
            {
                throw new Exception($" This Transaction Id  {TransactionId} not found.");
            }
            transactionEntity.IsTransactionApproved = verifyTransactionDto.IsTransactionApproved;
            transactionRepository.Update(transactionEntity);

            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();

           
            string activity = verifyTransactionDto.IsTransactionApproved
                ? $"Admin '{loggedInUserEmail}' approved transaction with ID '{TransactionId}'."
                : $"Admin '{loggedInUserEmail}' rejected transaction with ID '{TransactionId}'.";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return transactionEntity;

        }

        public List<Transactionn> GetAllApprovedTransaction()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Approved Transactions ";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return transactionRepository.GetAll().Where( c => c.IsTransactionApproved == true).ToList();
        }

        public List<SalaryDistribution> GetAllPendingSalaryDistributions()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Pending Salary Distribution Request ";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return salaryDistributionRepository.GetAll().Where( c => c.IsSalaryCredit == false).ToList();    
        }

        public List<SalaryDistribution> GetAllApprovedSalaryDistributions()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail}  retrieved the list of all Pending Salary Distribution Request. ";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return salaryDistributionRepository.GetAll().Where(c => c.IsSalaryCredit == true).ToList();
        }


        public List<SalaryDistribution> VerifySalaryDistribution(int salaryDistributionId, VerifySalaryDistributionDto verifySalaryDistributionDto)
        {
            var records = GetAllPendingSalaryDistributions();

            var updatedDistributions = new List<SalaryDistribution>();

            foreach (var found in records)
            {
                if (found.SalaryDisbutionId == salaryDistributionId)
                {
                    found.IsSalaryCredit = verifySalaryDistributionDto.IsSalaryCredit;

                    salaryDistributionRepository.Update(found);
                    updatedDistributions.Add(found);
                }
            }

            if (updatedDistributions.Count == 0)
            {
                throw new Exception($"This salary ID {salaryDistributionId} was not found in pending records.");
            }

            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();

           
            string activity = verifySalaryDistributionDto.IsSalaryCredit
                ? $"User '{loggedInUserEmail}' verified salary distribution for SalaryDistributionId '{salaryDistributionId}'."
                : $"User '{loggedInUserEmail}' marked salary distribution as not verified for SalaryDistributionId '{salaryDistributionId}'.";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);


            return updatedDistributions;
        }

    }
}
