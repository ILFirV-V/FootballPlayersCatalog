using System.ComponentModel.DataAnnotations;

namespace FootballPlayersCatalog.Attributes
{
    public class NameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var name = value.ToString();
                if (!string.IsNullOrEmpty(name))
                {
                    foreach (var c in name)
                    {
                        if (char.IsNumber(c))
                        {
                            return new ValidationResult("Name should contain only letters.");
                        }
                    }
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Name is required.");
        }
    }
}
