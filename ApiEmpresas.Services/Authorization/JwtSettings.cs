namespace ApiEmpresas.Services.Authorization
{
    /// <summary>
    /// Modelo de dados do conteúdo do TOKEN
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Chave secreta antifalsificação do token
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Tempo de expiração em horas
        /// </summary>
        public int ExpirationInHours { get; set; }
    }
}
