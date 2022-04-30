using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Interfaces;
using ApiEmpresas.Services.Requests;
using ApiEmpresas.Services.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpresas.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        //atributo
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //construtor para injeção de dependência
        public EmpresasController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(EmpresaPostRequest request)
        {
            try
            {
                //verificar se o CNPJ informado já está cadastrado..
                if (_unitOfWork.EmpresaRepository.ObterPorCnpj(request.Cnpj) != null)
                    //HTTP 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422, new { message = "O CNPJ informado já está cadastrado." });

                var empresa = _mapper.Map<Empresa>(request);
                empresa.IdEmpresa = Guid.NewGuid();

                //gravar no banco de dados
                _unitOfWork.EmpresaRepository.Inserir(empresa);

                var response = _mapper.Map<EmpresaResponse>(empresa);

                //HTTP 201 -> SUCCESS CREATED
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(EmpresaPutRequest request)
        {
            try
            {
                //pesquisando a empresa atraves do id..
                var empresa = _unitOfWork.EmpresaRepository.ObterPorId(request.IdEmpresa);

                //verificando se a empresa não foi encontrada
                if (empresa == null)
                    //HTTP 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422, new { message = "Empresa não encontrada, verifique o ID informado." });

                //verificando se o cnpj informado ja está cadastrado para outra empresa
                var registro = _unitOfWork.EmpresaRepository.ObterPorCnpj(request.Cnpj);
                if (registro != null && registro.IdEmpresa != empresa.IdEmpresa)
                    //HTTP 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422, new { message = "O CNPJ informado já está cadastrado para outra empresa." });

                //atualizando os dados da empresa
                empresa = _mapper.Map<Empresa>(request);

                _unitOfWork.EmpresaRepository.Alterar(empresa);

                var response = _mapper.Map<EmpresaResponse>(empresa);

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idEmpresa}")]
        public IActionResult Delete(Guid idEmpresa)
        {
            try
            {
                //pesquisando a empresa atraves do id..
                var empresa = _unitOfWork.EmpresaRepository.ObterPorId(idEmpresa);

                //verificando se a empresa não foi encontrada
                if (empresa == null)
                    //HTTP 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422, new { message = "Empresa não encontrada, verifique o ID informado." });

                //excluindo a empresa
                _unitOfWork.EmpresaRepository.Excluir(empresa);

                var response = _mapper.Map<EmpresaResponse>(empresa);

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var empresas = _unitOfWork.EmpresaRepository.Consultar();

                var lista = _mapper.Map<List<EmpresaResponse>>(empresas);

                if (lista.Count > 0)
                    return StatusCode(200, lista);
                else
                    return StatusCode(204);
            }
            catch (Exception e)
            {
                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idEmpresa}")]
        public IActionResult GetById(Guid idEmpresa)
        {
            try
            {
                //buscar a empresa no repositorio atraves do id
                var empresa = _unitOfWork.EmpresaRepository.ObterPorId(idEmpresa);

                //verificar se a empresa foi encontrada
                if (empresa != null)
                {
                    var response = _mapper.Map<EmpresaResponse>(empresa);

                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(204);
                }
            }
            catch (Exception e)
            {
                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);
            }
        }
    }
}



