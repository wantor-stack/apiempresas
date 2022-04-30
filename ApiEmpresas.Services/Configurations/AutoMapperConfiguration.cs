namespace ApiEmpresas.Services.Configurations
{
    /// <summary>
    /// Classe de configuração do AutoMapper
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Método para configuração do uso do AutoMapper
        /// </summary>
        public static void AddAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
