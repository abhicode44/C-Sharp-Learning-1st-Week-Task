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




        public CompanyService(IGenericRepository<Company> companyRepository,
            IGenericRepository<Benificiary> benificaryRepository,
            IGenericRepository<Transactionn> transactionnRepository,
            IGenericRepository<Employee> employeeRepository,
            IGenericRepository<SalaryDistribution> salaryDistributionRepository,
            IAuditService auditService,
            IHttpContextAccessor _httpContextAccessor
            )
        {
            this.repository = companyRepository;
            this.benificaryRepository = benificaryRepository;
            this.transactionnRepository = transactionnRepository;
            this.employeeRepository = employeeRepository;
            this.salaryDistributionRepository = salaryDistributionRepository;
            this._httpContextAccessor = _httpContextAccessor;
            this.auditService = auditService;
            
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



        public Company AddCompany(AddCompanyDto addCompanyDto)
        {
            var companyEntity = new Company
            {
                CompanyName = addCompanyDto.CompanyName,
                CompanyEmail = addCompanyDto.CompanyEmail,
                CompanyPassword = addCompanyDto.CompanyPassword,
                CompanyAddress = addCompanyDto.CompanyAddress,
                CompanyAccountNumber = addCompanyDto.CompanyAccountNumber,
                CompanyAccount_IFSCCode = addCompanyDto.CompanyAccount_IFSCCode,
                CompanyAadharCardFile = addCompanyDto.CompanyAadharCardFile,
                CompanyPanCardFile = addCompanyDto.CompanyPanCardFile,
                CompanyOfficalDocumnet = addCompanyDto.CompanyOfficalDocumnet,
                CompanyProfilePhoto = addCompanyDto.CompanyProfilePhoto,
                RoleId = 3,
                IsOTPVerified = false,
                IsDocumentVerified = false,
                IsCompanyLoginActive = true,
                DocumentStatusDesciption = "",
                CreatedAt = DateTime.Now,
            };
            repository.Add(companyEntity);


            string loggedEmail = addCompanyDto.CompanyEmail;
            string roleName = "Company"; 

            string activity = $"New company '{loggedEmail}' registered successfully.";

            auditService.AddToAuditLog(loggedEmail, activity, roleName);

            return companyEntity;

        }

       

        public Benificiary AddInBoundBenificiary (AddInBoundBenificiaryDto addInBoundBenificiaryDto) 
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

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return benificiaryEntity;

        }

        public Benificiary AddOutBoundBenificiary(AddOutBoundBenificiaryDto addOutBoundBenificiary)
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

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return benificiaryEntity ;
        }

        public Transactionn AddTransaction(AddTransactionDto addTransactionDto)
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

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return transactionEntity ;
        }




        public List<Employee> AddEmploye(IFormFile csvFile)
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

                    if (existingEmployee != null)
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
                  
                    employeeRepository.Add(employee);
                    employeeEntities.Add(employee);
                }

                if (employeeEntities.Any())
                {
                    string loggedInUserEmail = GetUserEmailFromJwt();
                    string loggedInUserRole = GetUserRoleFromJwt();
                    var activity = $" ({loggedInUserEmail}) added {employeeEntities.Count} new employees.";

                    auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

                }
            }
            return employeeEntities;
        }

        public List<Employee> GetAllEmployees()
        {
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();
            string activity = $"{loggedInUserEmail} retrieved the list of all Employees";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);

            return employeeRepository.GetAll();
        }

        public SalaryDistribution AddSalaryDistribution(AddSalaryDistributionDto addSalaryDistributionDto)
        {
            var salaryDistributionEntity = new SalaryDistribution
            {
                EmployeeEmail = addSalaryDistributionDto.EmployeeEmail,
                EmpSalary = addSalaryDistributionDto.EmpSalary,
                IsSalaryCredit = false,
                SalaryDescription = "Pending",
                CompanyEmail = addSalaryDistributionDto.CompanyEmail,
                SalaryTransactionDate = DateTime.Now,
            };
            salaryDistributionRepository.Add(salaryDistributionEntity);
            string loggedInUserEmail = GetUserEmailFromJwt();
            string loggedInUserRole = GetUserRoleFromJwt();

            string activity = $"{loggedInUserEmail} made a request for salary disbursement to Admin.";

            auditService.AddToAuditLog(loggedInUserEmail, activity, loggedInUserRole);
            return salaryDistributionEntity;

        }

    }
}
