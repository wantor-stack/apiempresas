using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    /// <summary>
    /// Modelagem da requisição de edição de empresa
    /// </summary>
    public class EmpresaPutRequest
    {
        [Required(ErrorMessage = "Informe a id da empresa.")]
        public Guid IdEmpresa { get; set; }

        [Required(ErrorMessage = "Informe o nome fantasia.")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "Informe a razão social.")]
        public string? RazaoSocial { get; set; }

        [Required(ErrorMessage = "Informe o cnpj.")]
        public string? Cnpj { get; set; }
    }
}

