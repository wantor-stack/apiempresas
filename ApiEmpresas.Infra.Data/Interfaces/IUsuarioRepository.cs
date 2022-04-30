using ApiEmpresas.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositorio para operações de usuário
    /// </summary>
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        /// <summary>
        /// Consultar 1 usuário através do email
        /// </summary>
        Usuario Obter(string email);

        /// <summary>
        /// Consultar 1 usuário através do email e senha
        /// </summary>
        Usuario Obter(string email, string senha);
    }
}

