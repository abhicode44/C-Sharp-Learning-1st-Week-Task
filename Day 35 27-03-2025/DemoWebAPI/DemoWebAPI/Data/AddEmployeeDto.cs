namespace DemoWebAPI.Data
{
    public class AddEmployeeDto
    {
        public required string EmployeName { get; set; }

        public required string Contact { get; set; }

        public required int Salary { get; set; }

        public bool IsActive { get; }
    }
}
