using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Services.Requests;
using AutoMapper;

namespace ApiEmpresas.Services.Mappings
{
    /// <summary>
    /// Mapeamento de objetos REQUEST para ENTITY
    /// </summary>
    public class RequestToEntityMap : Profile
    {
        public RequestToEntityMap()
        {
            CreateMap<EmpresaPostRequest, Empresa>();
            CreateMap<EmpresaPutRequest, Empresa>();

            CreateMap<FuncionarioPostRequest, Funcionario>();
            CreateMap<FuncionarioPutRequest, Funcionario>();    
        }
    }
}
