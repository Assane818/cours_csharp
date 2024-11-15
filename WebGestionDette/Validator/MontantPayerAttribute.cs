using System.ComponentModel.DataAnnotations;
using WebGestionDette.Data;
using WebGestionDette.Models;

namespace WebGestionDette.Validator;
public class MontantPayerAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Récupérer le contexte de la base de données
            var _context = (WebGesDetteContext)validationContext.GetService(typeof(WebGesDetteContext));

            // Récupérer l'instance de Payement
            var payement = validationContext.ObjectInstance as Payement;

            var dette = _context.Dettes.Find(payement.detteId);

            var montantPayer = (double)value;
            if (montantPayer > (dette.Montant - dette.MontantVerser))
            {
                return new ValidationResult("Le montant versé ne peut pas être supérieur au montant restant de la dette.");
            }

            return ValidationResult.Success;
        }
}