using ApiEmpresas.Infra.Data.Contexts;
using ApiEmpresas.Infra.Data.Interfaces;
using ApiEmpresas.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresas.Services.Configurations
{
    /// <summary>
    /// Classe para configuração do EntityFramework
    /// </summary>
    public static class EntityFrameworkConfiguration
    {
        /// <summary>
        /// Configurar o entity framework
        /// </summary>
        public static void AddEntityFramework(WebApplicationBuilder builder)
        {
            //capturar a string de conexão do banco de dados
            var connectionString = builder.Configuration.GetConnectionString("BDApiEmpresas");

            //injetar a connectionstring na classe SqlServerContext do EntityFramework
            builder.Services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(connectionString));

            //injeção de dependência para o UnitOfWork
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

