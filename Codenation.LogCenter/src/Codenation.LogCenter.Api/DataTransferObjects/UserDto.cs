using System.ComponentModel.DataAnnotations;

namespace Codenation.LogCenter.Api.DataTransferObjects
{
    public class UserDto
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
