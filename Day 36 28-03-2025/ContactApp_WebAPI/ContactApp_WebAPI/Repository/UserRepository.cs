using ContactApp_WebAPI.Data;
using ContactApp_WebAPI.Interface.IRepository;
using ContactApp_WebAPI.Model.Entity;
using ContactApp_WebAPI.Model.UserDto;
using Microsoft.EntityFrameworkCore;

namespace ContactApp_WebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyContext context;
        DbSet<User> dbSet;




        public UserRepository(MyContext context)
        {
            this.context = context;
            dbSet = context.Set<User>();
        }


        public List<User> GetAllUsers()
        {
            return dbSet.ToList();
        }

        //public User LoginUser(int userId, string password)
        //{


        //}

        public User AddStaff(User user)
        {
            var userEntity = new User
            {
                Name = user.Name,
                IsAdmin = false,
                IsActive = true,
                Password = user.Password,
            };

            dbSet.Add(userEntity);
            context.SaveChanges();
            return userEntity;
        }


        public User UpdateStaffName(int userId, UpdateUserNameDto updateUserNameDto)
        {
            var userEntity = dbSet.Find(userId);
            if (userEntity == null)
            {
                throw new KeyNotFoundException($"Staff with ID {userId} not found.");
            }

            userEntity.Name = updateUserNameDto.Name;
            context.SaveChanges();
            return userEntity;
        }


        public User UpdateStaffActivation(int userId, UpdateUserActivationDto updateUserActivationDto)
        {
            var userEntity = dbSet.Find(userId);
            if (userEntity == null)
            {
                throw new KeyNotFoundException($"Staff with ID {userId} not found.");
            }

            userEntity.IsActive = updateUserActivationDto.IsActive;
            context.SaveChanges();
            return userEntity;
        }


        public User GetByID(int userId)
        {
            var userEntity = dbSet.Find(userId);
            if (userEntity == null)
            {
                throw new KeyNotFoundException($"Staff with ID {userId} not found.");
            }

            return userEntity;
        }


        public User DeleteEmployees(int userId)
        {
            var userEntity = dbSet.Find(userId);
            if (userEntity == null)
            {
                throw new KeyNotFoundException($"Staff with ID {userId} not found.");
            }

            userEntity.IsActive = false;
            context.SaveChanges();
            return userEntity;
        }
    }
}
