using System.Reflection.Metadata.Ecma335;
using Bank_Application.Interface.GernralRepository;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;

namespace Bank_Application.Services
{
    public class AuditService : IAuditService
    {

        private readonly IGenericRepository<Audit> auditRepository;

        private readonly IServiceProvider _serviceProvider;

        public AuditService (IGenericRepository<Audit> auditRepository , IServiceProvider serviceProvider)
        {
            this.auditRepository = auditRepository;
            this._serviceProvider = serviceProvider;
        }


        public async Task<Audit> AddToAuditLog(string emailId, string activityPerformed, string roleName)
        {
            using var scope = _serviceProvider.CreateScope();
            var auditRepository = scope.ServiceProvider.GetRequiredService<IGenericRepository<Audit>>();
            
            var auditEntry = new Audit
            {
                UserEmail = emailId,
                ActivityPerformed = activityPerformed,
                TimeOfActivity = DateTime.Now,
                RoleName = roleName
            };

            try
            {
                await auditRepository.Add(auditEntry);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to insert audit: " + ex.Message);
                throw;
            }

            return auditEntry;
        }



    }
}
