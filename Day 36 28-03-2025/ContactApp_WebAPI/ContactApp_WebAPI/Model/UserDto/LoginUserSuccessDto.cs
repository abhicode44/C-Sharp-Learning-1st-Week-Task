namespace ContactApp_WebAPI.Model.UserDto
{
    public class LoginUserSuccessDto
    {
        public string Name { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }
    }
}
