using System.ComponentModel.DataAnnotations;

namespace DemoForm.Model
{
    public class Form
    {
        [Key]

        public int Id { get; set; }
        public string name {  get; set; }

        public string email { get; set; }

        public string password { get; set; }

    }
}
