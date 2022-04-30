using ApiEmpresas.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositório para operações de empresa
    /// </summary>
    public interface IEmpresaRepository : IBaseRepository<Empresa>
    {
        /// <summary>
        /// Mètodo para consultar 1 empresa através do Cnpj
        /// </summary>
        /// <param name="cnpj"></param>
        /// <returns></returns>
        Empresa ObterPorCnpj(string cnpj);
    }
}
