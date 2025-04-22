using Bank_Application.Data;
using Bank_Application.Interface.lRepository;
using Bank_Application.Model;
using Bank_Application.Model.AdminDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bank_Application.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly MyContext context;
        DbSet<Admin> dbset;

        public AdminRepository(MyContext context)
        {
            this.context = context;
            dbset = context.Set<Admin>();
        }



        public Admin AddAdmin(AddAdminDto addAdminDto)
        {
            var adminEntity = new Admin
            {
                AdminFirstName = addAdminDto.AdminFirstName,
                AdminLastName = addAdminDto.AdminLastName,
                AdminEmail = addAdminDto.AdminEmail,
                AdminPassword = addAdminDto.AdminPassword,
                IsAdminActive = true,
                RoleId = 1 ,
            };

            dbset.Add(adminEntity);
            context.SaveChanges();
            return adminEntity;
        }

        

        public Admin updateAdminActivation(int AdminId , AdminActivationDto activationDto)
        {
            var adminEntity = dbset.Find(AdminId);
            if (adminEntity == null) {
                throw new KeyNotFoundException($"Admin with ID {AdminId} not found.");
            }
            adminEntity.IsAdminActive = activationDto.IsAdminActive;
            context.SaveChanges();
            return adminEntity; 
        }

        public List<Admin> GetAllAdmin()
        {
            return dbset.ToList();
        }

    }
}