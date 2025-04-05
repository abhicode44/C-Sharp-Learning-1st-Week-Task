using ContactApp_WebAPI.Model.Entity;
using ContactApp_WebAPI.Model.UserDto;

namespace ContactApp_WebAPI.Interface.IRepository
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public User AddStaff(User user);
        public User UpdateStaffName(int userId, UpdateUserNameDto updateUserNameDto);
        public User UpdateStaffActivation(int userId, UpdateUserActivationDto updateUserActivationDto);
        public User GetByID(int userId);
        public User DeleteEmployees(int userId);
    }
}
