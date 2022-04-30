namespace ApiEmpresas.Services.Responses
{
    /// <summary>
    /// Modelagem de dados de retorno de funcionário na API
    /// </summary>
    public class FuncionarioResponse
    {
        public Guid IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public DateTime DataAdmissao { get; set; }

        #region Relacionamento

        public EmpresaResponse Empresa { get; set; }

        #endregion
    }
}
