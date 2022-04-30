using ApiEmpresas.Infra.Data.Contexts;
using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para injeção de dependência
        public FuncionarioRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Inserir(Funcionario entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Alterar(Funcionario entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Funcionario entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Funcionario> Consultar()
        {
            return _context.Funcionario
                .Include(f => f.Empresa) //INNER JOIN
                .OrderBy(f => f.Nome)
                .ToList();
        }

        public Funcionario ObterPorId(Guid id)
        {
            return _context.Funcionario
                .Include(f => f.Empresa) //INNER JOIN
                .FirstOrDefault(f => f.IdFuncionario.Equals(id));
        }

        public Funcionario ObterPorCpf(string cpf)
        {
            return _context.Funcionario
                .Include(f => f.Empresa) //INNER JOIN
                .FirstOrDefault(f => f.Cpf.Equals(cpf));
        }

        public Funcionario ObterPorMatricula(string matricula)
        {
            return _context.Funcionario
                .Include(f => f.Empresa) //INNER JOIN
                .FirstOrDefault(f => f.Matricula.Equals(matricula));
        }

        public List<Funcionario> ObterPorNome(string nome)
        {
            return _context.Funcionario
                .Include(f => f.Empresa) //INNER JOIN
                .Where(f => f.Nome.Contains(nome))
                .OrderBy(f => f.Nome)
                .ToList();
        }
    }
}



