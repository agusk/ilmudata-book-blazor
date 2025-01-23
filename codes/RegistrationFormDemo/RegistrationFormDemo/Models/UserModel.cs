using System.ComponentModel.DataAnnotations;

namespace RegistrationFormDemo.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public bool Agree { get; set; } = false;
    }
}
