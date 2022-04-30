using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    /// <summary>
    /// Modelagem da requisição de cadastro de usuário
    /// </summary>
    public class RegisterPostRequest
    {
        [Required(ErrorMessage = "Informe o nome do usuário.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        [Required(ErrorMessage = "Informe o email do usuário")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe a senha do usuário")]
        public string Senha { get; set; }
    }
}




