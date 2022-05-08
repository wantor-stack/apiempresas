using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Interfaces;
using ApiEmpresas.Messages.Services;
using ApiEmpresas.Services.Requests;
using ApiEmpresas.Services.Utils;
using Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpresas.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordRecoverController : ControllerBase
    {
        //atributos
        private readonly IUnitOfWork _unitOfWork;
        private readonly MailService _mailService;

        //construtor para injeção de dependência
        public PasswordRecoverController(IUnitOfWork unitOfWork, MailService mailService)
        {
            _unitOfWork = unitOfWork;
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult Post(PasswordRecoverPostRequest request)
        {
            try
            {
                //buscar o usuário no banco de dados através do email
                var usuario = _unitOfWork.UsuarioRepository.Obter(request.Email);

                //verificar se o usuário foi encontrado
                if (usuario != null)
                {
                    #region Enviando email de recuperação de senha

                    var novaSenha = new Faker().Internet.Password();
                    EnviarEmailDeRecuperacaoDeSenha(usuario, novaSenha);

                    #endregion

                    #region Atualizando a senha no banco de dados

                    usuario.Senha = Criptografia.GetMD5(novaSenha);
                    _unitOfWork.UsuarioRepository.Alterar(usuario);

                    #endregion

                    return StatusCode(200, new { message = "Recuperação de senha realizada com sucesso, por favor verifique seu email." });
                }
                else
                {
                    return StatusCode(422, new { message = "O email informado não foi encontrado, por favor verifique." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private void EnviarEmailDeRecuperacaoDeSenha(Usuario usuario, string novaSenha)
        {
            var subject = "Recuperação de senha de usuário - COTI Informática";

            var body = $@"
                     <div style='text-align: center; margin: 40px; padding: 60px; border: 2px solid #ccc; font-size: 16pt;'>
                     <img src='https://www.cotiinformatica.com.br/imagens/logo-coti-informatica.png' />
                     <br/><br/>
                     Olá <strong>{usuario.Nome}</strong>,
                     <br/><br/>    
                     O sistema gerou uma nova senha para que você possa acessar sua conta.<br/>
                     Por favor utilize a senha: <strong>{novaSenha}</strong>
                     <br/><br/>
                     Não esqueça de, ao acessar o sistema, atualizar esta senha para outra
                     de sua preferência.
                     <br/><br/>              
                     Att<br/>   
                     Equipe COTI Informatica
                     </div>
            ";

            _mailService.SendMail(usuario.Email, subject, body);
        }
    }
}



