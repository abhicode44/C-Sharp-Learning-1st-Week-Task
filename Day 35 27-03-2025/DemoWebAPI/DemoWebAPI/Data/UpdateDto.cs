namespace DemoWebAPI.Data
{
    public class UpdateDto
    {
        public required string EmployeName { get; set; }

        public required string Contact { get; set; }

        public required int Salary { get; set; }

        public bool IsActive { get; set; }
    }
}
