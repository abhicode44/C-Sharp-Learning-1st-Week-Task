namespace Bank_Application.Model.SalaryDistrubutionDto
{
    public class VerifySalaryDistributionDto
    {
        public bool IsSalaryCredit { get; set; }

        public List<int> SalaryDistributionIds { get; set; } = new List<int>();

      

        public string SalaryDescription { get; set; }
    }
}
