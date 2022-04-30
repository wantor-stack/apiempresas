using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de unidade de trabalho d o EntityFramework
    /// </summary>
    public interface IUnitOfWork
    {
        #region Métodos para controle da trnasação

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion

        #region Métodos para acesso aos repositórios

        public IEmpresaRepository EmpresaRepository { get; }
        public IFuncionarioRepository FuncionarioRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }

        #endregion
    }
}
