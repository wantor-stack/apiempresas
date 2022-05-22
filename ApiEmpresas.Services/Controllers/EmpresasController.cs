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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

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
                if (_unitOfWork.EmpresaRepository.ObterPorCnpj(request.Cnpj) != null)
                    return StatusCode(422, new { message = "O CNPJ informado já está cadastrado." });

                var empresa = _mapper.Map<Empresa>(request);
                empresa.IdEmpresa = Guid.NewGuid();

                _unitOfWork.EmpresaRepository.Inserir(empresa);

                var response = _mapper.Map<EmpresaResponse>(empresa);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(EmpresaPutRequest request)
        {
            try
            {
                var empresa = _unitOfWork.EmpresaRepository.ObterPorId(request.IdEmpresa);

                if (empresa == null)
                    return StatusCode(422, new { message = "Empresa não encontrada, verifique o ID informado." });

                var registro = _unitOfWork.EmpresaRepository.ObterPorCnpj(request.Cnpj);
                if (registro != null && registro.IdEmpresa != empresa.IdEmpresa)
                    return StatusCode(422, new { message = "O CNPJ informado já está cadastrado para outra empresa." });

                _mapper.Map(request, empresa);

                _unitOfWork.EmpresaRepository.Alterar(empresa);

                var response = _mapper.Map<EmpresaResponse>(empresa);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idEmpresa}")]
        public IActionResult Delete(Guid idEmpresa)
        {
            try
            {
                var empresa = _unitOfWork.EmpresaRepository.ObterPorId(idEmpresa);

                if (empresa == null)
                    return StatusCode(422, new { message = "Empresa não encontrada, verifique o ID informado." });

                _unitOfWork.EmpresaRepository.Excluir(empresa);

                var response = _mapper.Map<EmpresaResponse>(empresa);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
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
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idEmpresa}")]
        public IActionResult GetById(Guid idEmpresa)
        {
            try
            {
                var empresa = _unitOfWork.EmpresaRepository.ObterPorId(idEmpresa);

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
                return StatusCode(500, e.Message);
            }
        }
    }
}



