using System.Diagnostics;
using AutoMapper;
using Bank_Application.Controllers;
using Bank_Application.Helper;
using Bank_Application.Interface.GernralRepository;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.BankDto;
using Bank_Application.Model.BenificiaryDto;
using Bank_Application.Model.CompanyDto;
using Bank_Application.Model.SalaryDistrubutionDto;
using Bank_Application.Model.TransactionDto;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Bank_Application.Services
{
    public class AdminService : IAdminService
    {   
        IGenericRepository<Admin> repository;
        IGenericRepository<Company> companyRepository;
        IGenericRepository<Bank> bankRepository ;
        IGenericRepository<Benificiary> benificaryRepository;
        IGenericRepository<Transactionn> transactionRepository;
        IGenericRepository<SalaryDistribution> salaryDistributionRepository;
        IAuditService auditService;
        IHttpContextAccessor _httpContextAccessor;
        Cloudinary _cloudinary;
        IPhotoService _photoService;
        IMapper mapper;

        public AdminService( IGenericRepository <Admin> adminRepository ,
            IGenericRepository <Company> companyRepository , 
            IGenericRepository<Bank> bankRepository ,
            IGenericRepository<Benificiary> benificiaryRepository,
            IGenericRepository<Transactionn> transactionRepository ,
            IGenericRepository<SalaryDistribution> salaryDistributionRepository , 
            IAuditService auditService , 
            IHttpContextAccessor httpContextAccessor,
            IOptions<CloudinarySettings> cloudinaryOptions,
            IPhotoService photoService,
            IMapper mapper

            )
        {
            this.repository = adminRepository;
            this.bankRepository = bankRepository;
            this.companyRepository = companyRepository;
            this.benificaryRepository = benificiaryRepository;
            this.transactionRepository = transactionRepository;
            this.salaryDistributionRepository = salaryDistributionRepository;
            this.auditService = auditService;
            this._httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;


            var acc = new Account(
            cloudinaryOptions.Value.CloudName,
            cloudinaryOptions.Value.ApiKey,
            cloudinaryOptions.Value.ApiSecret);
            _photoService = photoService;
            _cloudinary = new Cloudinary(acc);

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


        public async Task<string> AddAdmin(AddAdminDto addAdminDto)
        {


            var existingAdmin = await repository.GetByConditionAsync(a => a.AdminEmail == addAdminDto.AdminEmail);
            if (existingAdmin != null)
            {
                throw new InvalidOperationException("An admin with this email already exists.");
            }


            var uploadAdminProfilePhoto = await _photoService.AddPhotoAsync(addAdminDto.AdminProfilePhoto);

            

            var adminEntity = mapper.Map<Admin>(addAdminDto);


            
            adminEntity.AdminProfilePhoto = uploadAdminProfilePhoto.SecureUrl.AbsoluteUri;
            adminEntity.IsAdminActive = true;
            adminEntity.RoleId = 1;

            
            await repository.Add(adminEntity);

            
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();

           
            string activity = $"Admin {loggedInUserEmail} added new admin: {addAdminDto.AdminEmail}";
            await auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            
            return "Admin Added Successfully" ;
        }



        public  async Task<Admin> updateAdminActivation(int AdminId, AdminActivationDto activationDto)
        {
            var adminEntity = await repository.GetById(AdminId);

            if (adminEntity == null)
            {
                throw new KeyNotFoundException($"Admin with ID {AdminId} not found!");
            }

            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();

            string activity = $"{loggedInUserEmail} {(activationDto.IsAdminActive ? "activated" : "deactivated")} admin account: {adminEntity.AdminEmail}";

            adminEntity.IsAdminActive = activationDto.IsAdminActive;

            await  repository.Update(adminEntity);

            await auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return adminEntity;

        }

        public async Task<Bank> AddBank(AddBankDto addBankDto)
        {
            var bankEntity = mapper.Map<Bank>(addBankDto);
            bankEntity.RoleId = 2;
            await bankRepository.Add(bankEntity);
            return bankEntity;

        }


        public async Task<List<Bank>> GetAllBank()
        {
            return bankRepository.GetAll().ToList();
        }

        public async Task<List<Admin>> GetAllAdmin()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all admins";

             auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return await repository.GetAll().ToListAsync();

        }


        public async Task<Company> UpdateDocumentVerify(string CompanyEmail, DocumentVerifyDto documentVerifyDto) {
            var companyEntity = await  companyRepository.GetByEmail(CompanyEmail);

            if (companyEntity == null)
            {
                throw new Exception($" This Company Email Id  {CompanyEmail} not found.");
            }

            companyEntity.IsDocumentVerified = documentVerifyDto.IsDocumentVerified;
            companyEntity.DocumentStatusDesciption = documentVerifyDto.DocumentStatusDesciption;
            await companyRepository.Update(companyEntity);

            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();

            string activity = documentVerifyDto.IsDocumentVerified
             ? $"Admin '{loggedInUserEmail}' verified documents for company '{CompanyEmail}'."
            : $"Admin '{loggedInUserEmail}' marked document verification failed for company '{CompanyEmail}'.";

            await auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return companyEntity;
        }


        public async Task<List<Company>> GetAllApprovedCompanies()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Approved Companies ";

           await  auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

           var approvedCompanies = await companyRepository.GetAll()
                                                      .Where(c => c.IsDocumentVerified == true)
                                                      .ToListAsync();
            
            return approvedCompanies;

        }

        public async Task<List<Company>> GetAllPendingCompanies()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Pending Companies ";

            await auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            var pendingCompines =  companyRepository.GetAll().Where(c => c.IsDocumentVerified == false).ToList();
            
            return pendingCompines;

        }

        public async Task<List<Benificiary>> GetAllPendingOutBenificiaryBoundCompany()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Pending OutBound Benificiary Companies ";

            await auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            var pendingOutBoundBenificiary =  benificaryRepository.GetAll().Where(c => c.IsBenificiaryApproved == false).ToList();

            return pendingOutBoundBenificiary;

        }

       

        public async Task<Benificiary> VerifyOutBoundCompany(int BenificiaryId, VerifyOutBoundCompanyDto verifyOutBoundCompanyDto)
        {
           var benificiaryEntity = await benificaryRepository.GetById(BenificiaryId);
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

            await auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return benificiaryEntity;
        }

        public async Task<List<Benificiary>> GetAllApprovedOutBenificiaryBoundCompany()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Pending OutBound Benificiary Companies. ";

            await  auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            var approvedOutBound = benificaryRepository.GetAll().Where(c => c.IsBenificiaryApproved == true).ToList();
            return approvedOutBound;

        }

        public async Task<List<Transactionn>> GetAllPendingTransactionRequest()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Pending Transactions Request ";

            await auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return transactionRepository.GetAll().Where(c => c.IsTransactionApproved == false).ToList();
        }

        public async Task<Transactionn> VerifyTransactionRequest(int TransactionId, VerifyTransactionDto verifyTransactionDto)
        {
            var transactionEntity = await transactionRepository.GetById(TransactionId);   
            if (transactionEntity == null)
            {
                throw new Exception($" This Transaction Id  {TransactionId} not found.");
            }
            transactionEntity.IsTransactionApproved = verifyTransactionDto.IsTransactionApproved;
            transactionEntity.TransactionDescription = verifyTransactionDto.TransactionDescription;
            transactionRepository.Update(transactionEntity);

            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();

           
            string activity = verifyTransactionDto.IsTransactionApproved
                ? $"Admin '{loggedInUserEmail}' approved transaction with ID '{TransactionId}'."
                : $"Admin '{loggedInUserEmail}' rejected transaction with ID '{TransactionId}'.";

            await  auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return transactionEntity;

        }

        public async Task<List<Transactionn>> GetAllApprovedTransaction()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Approved Transactions ";

            await auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            var approvedTransaction = transactionRepository.GetAll().Where( c => c.IsTransactionApproved == true).ToList();
            return approvedTransaction;


        }


        public async Task<List<SalaryDistribution>> GetAllPendingSalaryDistributions()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Pending Salary Distribution Request ";

            await auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            var pendingSalary = salaryDistributionRepository.GetAll().Where( c => c.IsSalaryCredit == false).ToList();  
            return pendingSalary;

        }

        public async Task<List<SalaryDistribution>> GetAllApprovedSalaryDistributions()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail}  retrieved the list of all Pending Salary Distribution Request. ";

           await  auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return salaryDistributionRepository.GetAll().Where(c => c.IsSalaryCredit == true).ToList();
        }


        public async  Task<List<SalaryDistribution>> VerifySalaryDistribution(int salaryDistributionId, VerifySalaryDistributionDto verifySalaryDistributionDto)
        {
            var records = await GetAllPendingSalaryDistributions();

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
