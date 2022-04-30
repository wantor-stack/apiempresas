using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    /// <summary>
    /// Modelagem de requisição de cadastro de funcionario
    /// </summary>
    public class FuncionarioPostRequest
    {
        [Required(ErrorMessage = "Por Favor, informe o nome do funcionário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por Favor, informe o cpf do funcionário.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por Favor, informe a matricula do funcionário.")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Por Favor, informe a data de admissão do funcionário.")]
        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "Por Favor, informe o id da empresa.")]
        public Guid IdEmpresa { get; set; }
    }
}
