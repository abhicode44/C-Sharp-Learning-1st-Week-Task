using Bank_Application.Model;
using Bank_Application.Model.AdminDto;

namespace Bank_Application.Interface.lRepository
{
    public interface IAdminRepository
    {
        public Admin AddAdmin (AddAdminDto addAdminDto);

    }
}
