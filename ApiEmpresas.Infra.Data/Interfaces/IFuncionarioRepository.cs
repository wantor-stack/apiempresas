using ApiEmpresas.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositorio para operações de funcionario
    /// </summary>
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        /// <summary>
        /// Método para retornar 1 funcionario baseado no cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        Funcionario ObterPorCpf(string cpf);

        /// <summary>
        /// Método para retornar 1 funcionario baseado na matrícula
        /// </summary>
        /// <param name="matricula"></param>
        /// <returns></returns>
        Funcionario ObterPorMatricula(string matricula);

        /// <summary>
        /// Método para retornar funcionarios baseados no nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        List<Funcionario> ObterPorNome(string nome);
    }
}
