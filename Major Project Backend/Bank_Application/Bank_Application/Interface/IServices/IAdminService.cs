using Bank_Application.Model;
using Bank_Application.Model.AdminDto;

namespace Bank_Application.Interface.IServices
{
    public interface IAdminService
    {
        public Admin AddAdmin(AddAdminDto addAdminDto);
        
    }
}
