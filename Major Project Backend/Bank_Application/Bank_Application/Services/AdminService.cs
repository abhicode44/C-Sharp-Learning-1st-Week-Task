using Bank_Application.Interface.GernralRepository;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;
using Bank_Application.Model.AdminDto;

namespace Bank_Application.Services
{
    public class AdminService : IAdminService
    {   
        IGenericRepository<Admin> repository;

        public AdminService(IGenericRepository <Admin> adminRepository)
        {
            this.repository = adminRepository;
        }
        public Admin AddAdmin(AddAdminDto addAdminDto)
        {
            var adminEntity = new Admin
            {
                AdminUserName = addAdminDto.AdminUserName,
                AdminPassword = addAdminDto.AdminPassword,
                RoleId =  1 
            };
            repository.Add(adminEntity);
            return adminEntity;
        }
    }
}
