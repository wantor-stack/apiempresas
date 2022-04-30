using ApiEmpresas.Infra.Data.Contexts;
using ApiEmpresas.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Repositories
{
    /// <summary>
    /// Classe para implementar a unidade de trabalho do EntituyFramework
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        //atributo
        private readonly SqlServerContext _context;
        private IDbContextTransaction _transaction;

        //construtor para injeção de dependência
        public UnitOfWork(SqlServerContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public IEmpresaRepository EmpresaRepository => new EmpresaRepository(_context);

        public IFuncionarioRepository FuncionarioRepository => new FuncionarioRepository(_context);

        public IUsuarioRepository UsuarioRepository => new UsuarioRepository(_context);
    }
}

