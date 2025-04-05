using ContactApp_WebAPI.Interface.IRepository;
using ContactApp_WebAPI.Interface.IServices;
using ContactApp_WebAPI.Model.Entity;
using ContactApp_WebAPI.Model.UserDto;

namespace ContactApp_WebAPI.Services
{
    public class UserServices : IUserServices
    {
        IUserRepository repository;
        public UserServices(IUserRepository userRepository)
        {
            this.repository = userRepository;
        }


        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            foreach (var user in repository.GetAllUsers())
            {
                if (user.IsActive == true)
                {
                    users.Add(user);
                }
            }
            return users;
        }

        public User LoginUser(int userId, string password)
        {
            var user = repository.GetByID(userId);
            bool pass = BCrypt.Net.BCrypt.EnhancedVerify(password, user.Password);
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
            return repository.AddStaff(user);
        }


        public User UpdateStaffName(int userId, UpdateUserNameDto updateUserNameDto)
        {
            return repository.UpdateStaffName(userId, updateUserNameDto);
        }


        public User UpdateStaffActivation(int userId, UpdateUserActivationDto updateUserActivationDto)
        {
            return repository.UpdateStaffActivation(userId, updateUserActivationDto);
        }


        public User GetByID(int userId)
        {
            return repository.GetByID(userId);
        }


        public User DeleteEmployees(int userId)
        {
            return repository.DeleteEmployees(userId);
        }
    }
}
