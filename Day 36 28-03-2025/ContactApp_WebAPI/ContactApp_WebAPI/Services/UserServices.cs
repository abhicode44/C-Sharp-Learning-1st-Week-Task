using ContactApp_WebAPI.Data;
using ContactApp_WebAPI.Interface;
using ContactApp_WebAPI.Interface.IRepository;
using ContactApp_WebAPI.Interface.IServices;
using ContactApp_WebAPI.Model.Entity;
using ContactApp_WebAPI.Model.UserDto;
using Microsoft.EntityFrameworkCore;

namespace ContactApp_WebAPI.Services
{
    public class UserServices : IUserServices
    {
        //IUserRepository repository;
        IGenericRepository<User> repository;

        
        

        public UserServices(IGenericRepository<User> userRepository ) 
        {
            this.repository = userRepository;
            
        }


        public IEnumerable<User> GetAllUsers()
        {
            //List<User> users = new List<User>();

            //List<User> users1 = repository.GetAll();
            //IEnumerator<User> enumerator = repository.GetAll().GetEnumerator();

            //foreach (var user in repository.GetAll())
            //{
            //    if (user.IsActive == true)
            //    {
            //        users.Add(user);
            //    }
            //}

            return repository.GetAll().Where(u => u.IsActive== true );
        }

        public User LoginUser(int userId, string password)
        {
            var user = repository.GetById(userId);
            bool pass = BCrypt.Net.BCrypt.EnhancedVerify(password,user.Password);
            if (pass)
            {
                return user;
            }
            else
            {
                return null;
            }

             //return repository.LoginUser(userId, password);
        }


        public User AddStaff(User user)
        {
            var userEntity = new User
            {
                Name = user.Name,
                IsAdmin = false,
                IsActive = true,
                Password = user.Password,
            };

            repository.Add(userEntity);
            //context.SaveChanges();
            return userEntity;

        }


        public User UpdateStaffName(int userId, UpdateUserNameDto updateUserNameDto)
        {
            //return repository.Update(userId, updateUserNameDto);

            var userEntity = repository.GetById(userId);
            if (userEntity == null)
            {
                throw new KeyNotFoundException($"Staff with ID {userId} not found.");
            }

            userEntity.Name = updateUserNameDto.Name;
            repository.Update(userEntity);
            //context.SaveChanges();
            return userEntity;

        }


        public User UpdateStaffActivation(int userId, UpdateUserActivationDto updateUserActivationDto)
        {
            //return repository.Update(userId, updateUserActivationDto);

            var userEntity = repository.GetById(userId);
            if (userEntity == null)
            {
                throw new KeyNotFoundException($"Staff with ID {userId} not found.");
            }

            userEntity.IsActive = updateUserActivationDto.IsActive;
            //context.SaveChanges();
            repository.Update(userEntity);
            return userEntity;
        }


        public User GetByID(int userId)
        {
            return repository.GetById(userId);
        }


        public User DeleteEmployees(int userId)
        {
            //return repository.Delete(userId);

            var userEntity = repository.GetById(userId);
            if (userEntity == null)
            {
                throw new KeyNotFoundException($"Staff with ID {userId} not found.");
            }

            userEntity.IsActive = false;
            repository.Delete(userEntity);
            //context.SaveChanges();
            return userEntity;

        }
    }
}
