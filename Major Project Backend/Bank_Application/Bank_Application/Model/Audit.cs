using System.ComponentModel.DataAnnotations;

namespace Bank_Application.Model
{
    public class Audit
    {
        [Key]
        public int AuditLogId { get; set; }

        [Required]

        public string UserEmail { get; set; }

        [Required]
        public string ActivityPerformed { get; set;}

        [Required]
        public DateTime TimeOfActivity {  get; set;}


        [Required]
        public string RoleName { get; set; }
    }
}
