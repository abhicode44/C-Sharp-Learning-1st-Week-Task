namespace Bank_Application.Helper
{
    public interface IEmailServices
    {
       public  Task SendEmail(string toEmail, string subject, string body);
    }
}
