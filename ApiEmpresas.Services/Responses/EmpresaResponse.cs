namespace ApiEmpresas.Services.Responses
{
    /// <summary>
    /// Modelagem de dados de retorno da empresa na API
    /// </summary>
    public class EmpresaResponse
    {
        public Guid IdEmpresa { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }
    }
}

