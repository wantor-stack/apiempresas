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
    public class FuncionariosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FuncionariosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(FuncionarioPostRequest request)
        {
            try
            {
                if (_unitOfWork.FuncionarioRepository.ObterPorCpf(request.Cpf) != null)
                    return StatusCode(422, new { message = "O CPF informado já está cadastrado." });

                if (_unitOfWork.FuncionarioRepository.ObterPorMatricula(request.Matricula) != null)
                    return StatusCode(422, new { message = "A Matrícula informada já está cadastrado." });

                var empresa = _unitOfWork.EmpresaRepository.ObterPorId(request.IdEmpresa);
                if (empresa == null)
                    return StatusCode(422, new { message = "A Empresa informada não está cadastrada." });

                var funcionario = _mapper.Map<Funcionario>(request);
                funcionario.IdFuncionario = Guid.NewGuid();

                _unitOfWork.FuncionarioRepository.Inserir(funcionario);

                var response = _mapper.Map<FuncionarioResponse>(funcionario);
                response.Empresa = _mapper.Map<EmpresaResponse>(empresa);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(FuncionarioPutRequest request)
        {
            try
            {
                var funcionario = _unitOfWork.FuncionarioRepository.ObterPorId(request.IdFuncionario);

                if (funcionario == null)
                    return StatusCode(422, new { message = "Funcionário não encontrado, verifique o ID informado." });

                var registroCpf = _unitOfWork.FuncionarioRepository.ObterPorCpf(request.Cpf);
                if (registroCpf != null && registroCpf.IdFuncionario != funcionario.IdFuncionario)
                    return StatusCode(422, new { message = "O CPF informado já está cadastrado para outro funcionário." });

                var registroMatricula = _unitOfWork.FuncionarioRepository.ObterPorMatricula(request.Matricula);
                if (registroMatricula != null && registroMatricula.IdFuncionario != funcionario.IdFuncionario)
                    return StatusCode(422, new { message = "A Matrícula informada já está cadastrada para outro funcionário." });

                var empresa = _unitOfWork.EmpresaRepository.ObterPorId(request.IdEmpresa);
                if (empresa == null)
                    return StatusCode(422, new { message = "A Empresa informada não está cadastrada." });

                _mapper.Map(request, funcionario);
                _unitOfWork.FuncionarioRepository.Alterar(funcionario);

                var response = _mapper.Map<FuncionarioResponse>(funcionario);
                response.Empresa = _mapper.Map<EmpresaResponse>(empresa);

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idFuncionario}")]
        public IActionResult Delete(Guid idFuncionario)
        {
            try
            {
                var funcionario = _unitOfWork.FuncionarioRepository.ObterPorId(idFuncionario);

                if (funcionario == null)
                    return StatusCode(422, new { message = "Funcionário não encontrado, verifique o ID informado." });

                var empresa = _unitOfWork.EmpresaRepository.ObterPorId(funcionario.IdEmpresa);
                _unitOfWork.FuncionarioRepository.Excluir(funcionario);

                var response = _mapper.Map<FuncionarioResponse>(funcionario);
                response.Empresa = _mapper.Map<EmpresaResponse>(empresa);

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
                var funcionarios = _unitOfWork.FuncionarioRepository.Consultar();
                var lista = _mapper.Map<List<FuncionarioResponse>>(funcionarios);

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

        [HttpGet("{idFuncionario}")]
        public IActionResult GetById(Guid idFuncionario)
        {
            try
            {
                var funcionario = _unitOfWork.FuncionarioRepository.ObterPorId(idFuncionario);

                if (funcionario != null)
                {
                    var response = _mapper.Map<FuncionarioResponse>(funcionario);
                    return StatusCode(200, response);
                }
                else
                    return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}



