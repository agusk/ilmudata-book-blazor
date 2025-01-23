using CustomValidatorDemo.Validators;
using System.ComponentModel.DataAnnotations;

namespace CustomValidatorDemo.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;

        [CustomAgeValidator]
        public int Age { get; set; }
    }
}
