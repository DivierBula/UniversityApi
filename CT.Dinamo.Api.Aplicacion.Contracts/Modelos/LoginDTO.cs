using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CT.Dinamo.Api.Aplicacion.Contracts.ModelsDTO
{
    public class LoginDTO : IValidatableObject
    {
        [Required]
        public String Usuario { get; set; }
        //[RequiredPassword]
        public String Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var (validacion, resultado) = ObtenerValidacionCustomizada(Usuario, Password);
            if (!validacion)
                yield return resultado;
        }

        private (bool, ValidationResult) ObtenerValidacionCustomizada(string usuario, String password)
            => (string.IsNullOrWhiteSpace(usuario), string.IsNullOrWhiteSpace(password)) switch
            {
                (true, true) => (false, new ValidationResult("Falta un usuario y Password por diligenciar.")),
                (false, true) => (false, new ValidationResult("Falta un usuario por diligenciar.")),
                (true, false) => (false, new ValidationResult("Falta un password por diligenciar.")),
                _ => (true, null) // para el caso en el que no se requiera colocar el resto de condiciones

            };
    }

    public class RequiredPasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string reg = @"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$";

            if (System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), reg))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("La contraseña no cumple con los estandares.");
        }
    }
}
