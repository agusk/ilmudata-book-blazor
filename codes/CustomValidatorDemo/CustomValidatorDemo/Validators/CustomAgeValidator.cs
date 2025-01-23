using System.ComponentModel.DataAnnotations;

namespace CustomValidatorDemo.Validators
{
    public class CustomAgeValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int age && (age < 18 || age > 60))
            {
                return new ValidationResult("Age must be between 18 and 60.");
            }
            return ValidationResult.Success;
        }
    }
}
