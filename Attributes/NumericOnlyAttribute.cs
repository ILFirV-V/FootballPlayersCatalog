using System.ComponentModel.DataAnnotations;

namespace FootballPlayersCatalog.Attributes
{
    public class NumericOnlyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            var strValue = value.ToString();

            if (string.IsNullOrWhiteSpace(strValue))
                return ValidationResult.Success;

            if (strValue.All(char.IsDigit))
                return ValidationResult.Success;
            else
                return new ValidationResult("The field must contain only numeric characters.");
        }
    }
}
