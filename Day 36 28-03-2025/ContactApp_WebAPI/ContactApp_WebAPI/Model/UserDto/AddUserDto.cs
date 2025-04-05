namespace ContactApp_WebAPI.Model.UserDto
{
    public class AddUserDto
    {
        public string Name { get; set; }

        public bool IsAdmin { get; }

        public bool IsActive { get; }
        public string Password { get; set; }
    }
}
