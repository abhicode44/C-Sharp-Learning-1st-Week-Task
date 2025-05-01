using Bank_Application.Model;

namespace Bank_Application.Interface.IServices
{
    public interface IAuditService
    {
        public Task<Audit> AddToAuditLog(string emailId, string activityPerformed, string roleName);
       
    }
}
