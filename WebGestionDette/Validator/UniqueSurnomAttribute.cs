using System.ComponentModel.DataAnnotations;
using WebGestionDette.Data;

namespace WebGestionDette.Validator;

public class UniqueSurnameAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var _context = (WebGesDetteContext)validationContext.GetService(typeof(WebGesDetteContext));
        var surname = (string)value;
        if (_context.Clients.Any(c => c.Surname == surname))
        {
            return new ValidationResult("Ce surnom est déjà utilisé");
        }
        return ValidationResult.Success;
    }
}