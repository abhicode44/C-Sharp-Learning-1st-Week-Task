using System.Globalization;
using Bank_Application.Interface.GernralRepository;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.BenificiaryDto;
using Bank_Application.Model.CompanyDto;
using Bank_Application.Model.TransactionDto;
using CsvHelper.Configuration;
using CsvHelper;
using Bank_Application.Data;
using Bank_Application.Model.SalaryDistrubutionDto;
using Bank_Application.Controllers;
using Bank_Application.Helper;
using CloudinaryDotNet;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder.Extensions;

namespace Bank_Application.Services
{
    public class CompanyService  : ICompanyService
    {
        IGenericRepository<Company> repository;
        IGenericRepository<Benificiary> benificaryRepository;
        IGenericRepository<Transactionn> transactionnRepository;
        IGenericRepository<Employee> employeeRepository;
        IGenericRepository<SalaryDistribution> salaryDistributionRepository;
        IAuditService auditService;
        IHttpContextAccessor _httpContextAccessor;
        IMapper mapper;
        Cloudinary _cloudinary;
         IPhotoService _photoService;
        private readonly IEmailServices _emailService;



        public CompanyService(IGenericRepository<Company> companyRepository,
            IGenericRepository<Benificiary> benificaryRepository,
            IGenericRepository<Transactionn> transactionnRepository,
            IGenericRepository<Employee> employeeRepository,
            IGenericRepository<SalaryDistribution> salaryDistributionRepository,
            IAuditService auditService,
            IHttpContextAccessor _httpContextAccessor,
            IMapper mapper,
            IOptions<CloudinarySettings> cloudinaryOptions,
            IPhotoService photoService ,
            IEmailServices emailService
            )

        {
            this.repository = companyRepository;
            this.benificaryRepository = benificaryRepository;
            this.transactionnRepository = transactionnRepository;
            this.employeeRepository = employeeRepository;
            this.salaryDistributionRepository = salaryDistributionRepository;
            this._httpContextAccessor = _httpContextAccessor;
            this.auditService = auditService;
            this.mapper = mapper;
            _emailService = emailService;


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



        public async Task<string> AddCompany(AddCompanyDto addCompanyDto)
        {
            
            var uploadAadharFile = await _photoService.AddPhotoAsync(addCompanyDto.CompanyAadharCardFile);
            var uploadPanFile = await _photoService.AddPhotoAsync(addCompanyDto.CompanyPanCardFile);
            var uploadOfficialDocument = await _photoService.AddPhotoAsync(addCompanyDto.CompanyOfficalDocumnet);
            var uploadCompanyProfilePhoto = await _photoService.AddPhotoAsync(addCompanyDto.CompanyProfilePhoto);

            
            var companyEntity = mapper.Map<Company>(addCompanyDto);

            {

                companyEntity.CompanyAadharCardFile = uploadAadharFile.SecureUrl.AbsoluteUri;
                companyEntity.CompanyPanCardFile = uploadPanFile.SecureUrl.AbsoluteUri;
                companyEntity.CompanyOfficalDocumnet = uploadOfficialDocument.SecureUrl.AbsoluteUri;
                companyEntity.CompanyProfilePhoto = uploadCompanyProfilePhoto.SecureUrl.AbsoluteUri;
                companyEntity.RoleId = 3;
                companyEntity.IsOTPVerified = false;
                companyEntity.IsDocumentVerified = false;
                companyEntity.IsCompanyLoginActive = true;
                companyEntity.DocumentStatusDesciption = "";
                companyEntity.CreatedAt = DateTime.Now;
            };

            
            await repository.Add(companyEntity);

            string subject = "Company Registration Successful";
            string body = $"Dear {addCompanyDto.CompanyName}, " +  $"\n Your company has been successfully registered with us." + $"\n Thank you! ";
            await  _emailService.SendEmail( addCompanyDto.CompanyEmail , subject, body);

            return "New Company Added " ;
        }


        public async Task<Benificiary> AddInBoundBenificiary (AddInBoundBenificiaryDto addInBoundBenificiaryDto) 
        {
            var benificiaryEntity = new Benificiary
            {
                BenificiaryCompanyName = addInBoundBenificiaryDto.BenificiaryCompanyName,
                BenificiaryEmail = addInBoundBenificiaryDto.BenificiaryEmail,
                BenificiaryCompanyAccountNumber = addInBoundBenificiaryDto.BenificiaryCompanyAccountNumber,
                BenificiaryCompanyIFSCcode = addInBoundBenificiaryDto.BenificiaryCompanyIFSCcode,
                CompanyEmail = addInBoundBenificiaryDto.CompanyEmail,
                BenificiaryType = "Inbound",
                IsBenificiaryApproved = true,
                CreatedAt = DateTime.Now
            };
            benificaryRepository.Add(benificiaryEntity);

            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();

            string activity = $"Added inbound beneficiary '{addInBoundBenificiaryDto.BenificiaryCompanyName}'.";

            await auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return benificiaryEntity;

        }

        public async  Task<Benificiary> AddOutBoundBenificiary(AddOutBoundBenificiaryDto addOutBoundBenificiary)
        {
            var benificiaryEntity = new Benificiary
            {
                BenificiaryCompanyName = addOutBoundBenificiary.BenificiaryCompanyName,
                BenificiaryEmail = addOutBoundBenificiary.BenificiaryEmail,
                BenificiaryCompanyAccountNumber = addOutBoundBenificiary.BenificiaryCompanyAccountNumber,
                BenificiaryCompanyIFSCcode = addOutBoundBenificiary.BenificiaryCompanyIFSCcode,
                CompanyEmail = addOutBoundBenificiary.CompanyEmail,
                BenificiaryType = "Outbound",
                IsBenificiaryApproved = false,
                CreatedAt = DateTime.Now
            };
            benificaryRepository.Add(benificiaryEntity) ;
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();

            string activity = $"(Company: {loggedInUserEmail}) made a request to Admin for adding Outbound Beneficiary '{addOutBoundBenificiary.BenificiaryCompanyName}'.";

            await auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return benificiaryEntity ;
        }

        public  async Task<Transactionn> AddTransaction(AddTransactionDto addTransactionDto)
        {
            var transactionEntity = new Transactionn
            {
                TransferFromCompanyEmail = addTransactionDto.TransferFromCompanyEmail,  
                TransferToBenificaryCompanyEmail = addTransactionDto.TransferToBenificaryCompanyEmail,
                TransactionAmount = addTransactionDto.TransactionAmount,    
                IsTransactionApproved = false,
                TransactionDescription = "",
                PaymentDate = DateTime.Now,
            };
            transactionnRepository.Add(transactionEntity);

            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"Company '{loggedInUserEmail}'  made a transaction request to '{addTransactionDto.TransferToBenificaryCompanyEmail}' of amount {addTransactionDto.TransactionAmount}.";

            await  auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return transactionEntity ;
        }


        public async Task<List<Employee>> AddEmploye(IFormFile csvFile)
        {
            var employeeEntities = new List<Employee>();

            using (var stream = new StreamReader(csvFile.OpenReadStream()))
            using (var csvReader = new CsvReader(stream, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            }))
            {
                var records = csvReader.GetRecords<Employee>().ToList();

                foreach (var dto in records)
                {
                    var existingEmployee = employeeRepository.GetByEmail(dto.EmpEmail);

                    if (existingEmployee.Result != null  )
                    {
                        continue;
                    }

                    var employee = new Employee
                    {
                        EmpFirstName = dto.EmpFirstName,
                        EmpLastName = dto.EmpLastName,
                        EmpEmail = dto.EmpEmail,
                        EmpPhone = dto.EmpPhone,
                        EmpAddress = dto.EmpAddress,
                        EmpAccountNumber = dto.EmpAccountNumber,
                        EmpIFSCCode = dto.EmpIFSCCode,
                        EmpDepartment = dto.EmpDepartment,
                        EmpDesignation = dto.EmpDesignation,
                        EmployeeSalary = dto.EmployeeSalary,
                        CompanyEmail = dto.CompanyEmail
                    };
                  
                    await employeeRepository.Add(employee);
                    employeeEntities.Add(employee);
                }

                if (employeeEntities.Any())
                {
                    string loggedInUserEmail = GetUserEmailFromJwt();
                    string loggedInUserRole = GetUserRoleFromJwt();
                    var activity = $" ({loggedInUserEmail}) added {employeeEntities.Count} new employees.";

                    await auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

                }
            }
            return employeeEntities;
        }



        public async  Task<List<Employee>> GetAllEmployees()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Employees";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return employeeRepository.GetAll().Where(c => c.CompanyEmail == loggedInUserEmail).ToList();

        }


        public async Task<List<SalaryDistribution>> AddSalaryDistribution(AddSalaryDistributionDto addSalaryDistributionDto)
        {
            var salaryDistributions = new List<SalaryDistribution>();

            for (int i = 0; i < addSalaryDistributionDto.EmployeeEmails.Count; i++)
            {
                var salaryDistributionEntity = new SalaryDistribution
                {
                    EmployeeEmail = addSalaryDistributionDto.EmployeeEmails[i],
                    EmpSalary = addSalaryDistributionDto.EmpSalaries[i],
                    CompanyEmail = addSalaryDistributionDto.CompanyEmails[i],
                    IsSalaryCredit = false,
                    SalaryDescription = "Pending",
                    SalaryTransactionDate = DateTime.Now
                };

                await salaryDistributionRepository.Add(salaryDistributionEntity);
                salaryDistributions.Add(salaryDistributionEntity);
            }

            return salaryDistributions;
        }


        public async Task<List<Benificiary>> GetAllInboundBenificiary()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Inbound Beneficiary List";

            
            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            var inboundList = benificaryRepository.GetAll().Where(c => c.BenificiaryType == "Inbound" && c.CompanyEmail == loggedInUserEmail).ToList();

            return inboundList;

        }

        public async Task<List<Benificiary>> GetAllOutboundBenificiary()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Inbound Beneficiary List";


            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            var outboundList = benificaryRepository.GetAll().Where(c => c.BenificiaryType == "Outbound" && c.CompanyEmail == loggedInUserEmail && c.IsBenificiaryApproved == true).ToList();

            return outboundList;

        }

        public async Task<List<Benificiary>> GetAllApprovedBenificiary()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Approved Beneficiary List";


            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            var approvedlist = benificaryRepository.GetAll().Where(c => c.IsBenificiaryApproved && c.CompanyEmail == loggedInUserEmail).ToList();

            return approvedlist;
        }




    }
}
