using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    /// <summary>
    /// Modelagem da requisição de edição de funcionário
    /// </summary>
    public class FuncionarioPutRequest
    {
        [Required(ErrorMessage = "Por favor, informe o ID do funcionario")]
        public Guid IdFuncionario { get; set; }

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
