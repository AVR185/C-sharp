using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CodeBeerProject.Data;

namespace CodeBeerProject.Models
{
    class EmployeeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int empid))
            {
                if (!DatabaseConnection.EmployeeIdList.Contains(empid))
                {
                    return new ValidationResult(false, "El empleado con ese número de identificación no existe.");
                }
            }

            return ValidationResult.ValidResult;
        }
    }
}