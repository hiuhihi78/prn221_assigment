using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_Project.Validation
{
    public class NumericValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double result;
            if (value == null || !double.TryParse(value.ToString(), out result))
            {
                return new ValidationResult(false, "Input must be a number.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
