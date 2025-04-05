using System.Diagnostics.CodeAnalysis;

namespace ContactApp_WebAPI.Model.UserDto
{
    public class UpdateUserNameDto
    {
        [NotNull]
        public string Name { get; set; }
    }
}
