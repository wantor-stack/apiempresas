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
    public class UsuarioRepository : IUsuarioRepository
    {
        //atributo
        private readonly SqlServerContext _context;

        //construtor para injeção de dependência (inicialização)
        public UsuarioRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Inserir(Usuario entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Alterar(Usuario entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Excluir(Usuario entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<Usuario> Consultar()
        {
            return _context.Usuario
                .ToList();
        }

        public Usuario ObterPorId(Guid id)
        {
            return _context.Usuario
                .FirstOrDefault(u => u.IdUsuario == id);
        }

        public Usuario Obter(string email)
        {
            return _context.Usuario
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario Obter(string email, string senha)
        {
            return _context.Usuario
                .FirstOrDefault(u => u.Email.Equals(email)
                                  && u.Senha.Equals(senha));
        }
    }
}

