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
    public class EmpresaRepository : IEmpresaRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para injeção de dependência
        public EmpresaRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Inserir(Empresa entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Alterar(Empresa entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Empresa entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Empresa> Consultar()
        {
            return _context.Empresa
                .OrderBy(e => e.NomeFantasia)
                .ToList();
        }

        public Empresa ObterPorId(Guid id)
        {
            return _context.Empresa.FirstOrDefault(e => e.IdEmpresa.Equals(id));
        }

        public Empresa ObterPorCnpj(string cnpj)
        {
            return _context.Empresa.FirstOrDefault(e => e.Cnpj.Equals(cnpj));
        }       
    }
}
