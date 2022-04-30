using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Entities
{
    public class Funcionario
    {
        #region Priopriedades

        public Guid IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public DateTime DataAdmissao { get; set; }
        public Guid IdEmpresa { get; set; }

        #endregion

        #region Relacionamentos

        public Empresa Empresa { get; set; }

        #endregion
    }
}
