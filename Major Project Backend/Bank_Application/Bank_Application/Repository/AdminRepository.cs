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
                AdminUserName = addAdminDto.AdminUserName,
                AdminPassword = addAdminDto.AdminPassword,
                RoleId = 1 ,
            };

            dbset.Add(adminEntity);
            context.SaveChanges();
            return adminEntity;
        }

    }
}