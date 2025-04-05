using System.Diagnostics.CodeAnalysis;

namespace ContactApp_WebAPI.Model.UserDto
{
    public class UpdateUserActivationDto
    {
        [NotNull]
        public bool IsActive { get; set; }
    }
}
