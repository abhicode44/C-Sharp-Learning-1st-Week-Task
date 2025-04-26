using System.Reflection.Metadata.Ecma335;
using Bank_Application.Interface.GernralRepository;
using Bank_Application.Interface.IServices;
using Bank_Application.Model;

namespace Bank_Application.Services
{
    public class AuditService : IAuditService
    {

        private readonly IGenericRepository<Audit> auditRepository;
        
        public AuditService (IGenericRepository<Audit> auditRepository)
        {
            this.auditRepository = auditRepository;
        }


        public Audit AddToAuditLog(string emailId, string activityPerformed, string roleName)
        {
            var auditEntry = new Audit
            {
                UserEmail = emailId,
                ActivityPerformed = activityPerformed,
                TimeOfActivity = DateTime.Now,
                RoleName = roleName
            };

            auditRepository.Add(auditEntry); 
            return auditEntry;
        }

    }
}
