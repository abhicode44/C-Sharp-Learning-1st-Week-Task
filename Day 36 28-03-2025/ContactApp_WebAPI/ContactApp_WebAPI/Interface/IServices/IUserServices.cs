using ContactApp_WebAPI.Model.Entity;
using ContactApp_WebAPI.Model.UserDto;

namespace ContactApp_WebAPI.Interface.IServices
{
    public interface IUserServices
    {
        public IEnumerable<User> GetAllUsers();
        public User LoginUser(int userId, string password);
        public User AddStaff(User user);
        public User UpdateStaffName(int userId, UpdateUserNameDto updateUserNameDto);
        public User UpdateStaffActivation(int userId, UpdateUserActivationDto updateUserActivationDto);
        public User GetByID(int userId);
        public User DeleteEmployees(int userId);
    }
}
