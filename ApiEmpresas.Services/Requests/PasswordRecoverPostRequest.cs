using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    public class PasswordRecoverPostRequest
    {
        [Required(ErrorMessage = "Por favor, informe o email.")]
        [EmailAddress(ErrorMessage = "Por favor, informe um email válido.")]
        public string Email { get; set; }
    }
}

