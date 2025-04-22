using Bank_Application.Model;
using Bank_Application.Model.AdminDto;

namespace Bank_Application.Interface.lRepository
{
    public interface IAdminRepository
    {
        public List<Admin> GetAllAdmin();
        public Admin AddAdmin ( AddAdminDto addAdminDto);

        public Admin updateAdminActivation(int AdminId , AdminActivationDto activationDto);

    }
}
