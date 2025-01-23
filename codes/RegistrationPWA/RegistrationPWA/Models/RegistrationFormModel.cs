namespace RegistrationPWA.Models
{
    public class RegistrationFormModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public bool Agree { get; set; } = false;
    }
}
