using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.Model.Entity
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        public required string EmployeName { get; set; }

        public required string Contact {  get; set; }

        public required int Salary { get; set; }

        public bool IsActive { get; set; }


    }
}
