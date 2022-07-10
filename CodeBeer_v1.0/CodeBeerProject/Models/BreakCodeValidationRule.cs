using System.Globalization;
using System.Linq;
using System.Windows.Controls;
using CodeBeerProject.Data;

namespace CodeBeerProject.Models
{
    class BreakCodeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int breakcode))
            {
                if (!DatabaseConnection.Breaks.Select(b => b.BreakCode).Contains(breakcode))
                {
                    return new ValidationResult(false, "Este descanso no existe.");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}