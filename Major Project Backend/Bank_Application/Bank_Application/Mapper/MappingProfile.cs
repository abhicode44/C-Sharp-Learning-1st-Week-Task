using AutoMapper;
using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Bank_Application.Model.BankDto;
using Bank_Application.Model.BenificiaryDto;
using Bank_Application.Model.CompanyDto;
using Bank_Application.Model.SalaryDistrubutionDto;
using Bank_Application.Model.TransactionDto;

namespace Bank_Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Admin , AddAdminDto>();
            CreateMap<AddAdminDto, Admin>();

            CreateMap<Admin, AdminActivationDto>();
            CreateMap<AdminActivationDto , Admin>();

            CreateMap<Bank, AddBankDto>();
            CreateMap<AddBankDto, Bank>();

            CreateMap<Benificiary, AddInBoundBenificiaryDto>();
            CreateMap<AddInBoundBenificiaryDto, Benificiary>();

            CreateMap<Benificiary , AddOutBoundBenificiaryDto  >();
            CreateMap<AddOutBoundBenificiaryDto , Benificiary>();

            CreateMap<Benificiary , VerifyOutBoundCompanyDto>();
            CreateMap<VerifyOutBoundCompanyDto, Benificiary>();

            CreateMap<Company , AddCompanyDto>();
            CreateMap<AddCompanyDto , Company>();

            CreateMap<Company , DocumentVerifyDto>();
            CreateMap<DocumentVerifyDto , Company>();

            CreateMap<SalaryDistribution, AddSalaryDistributionDto>();
            CreateMap<AddSalaryDistributionDto, SalaryDistribution>();

            CreateMap<SalaryDistribution, VerifySalaryDistributionDto>();
            CreateMap<VerifySalaryDistributionDto, SalaryDistribution>();

            CreateMap<Transactionn, AddTransactionDto>();
            CreateMap<AddTransactionDto , Transactionn>();

            CreateMap<Transactionn , VerifyTransactionDto>();
            CreateMap < VerifyTransactionDto , Transactionn>();

        }
    }
}
