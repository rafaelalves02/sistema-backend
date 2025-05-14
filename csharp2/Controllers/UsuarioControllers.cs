using csharp2.models;
using csharp2.services;
using Microsoft.AspNetCore.Mvc;

namespace csharp2.controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("login")]    
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {
            var result = new LoginResult();


            if (request == null)
            {
                result.Sucesso = false;
                result.Mensagem = "request = null";
            }
            else if (request.Email == "")
            {
                result.Sucesso = false;
                result.Mensagem = "preencha o campo E-mail";
            }
            else if (request.Senha == "")
            {
                result.Sucesso = false;
                result.Mensagem = "preencha o campo senha";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("cursoRenatoGavaDb");

                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Login(request.Email, request.Senha);
            }

            return result;
        }


        [Route("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null)
            {
                result.Sucesso = false;
                result.Mensagem = "request = null";
            }
            else if (string.IsNullOrWhiteSpace(request.Nome))
            {
                result.Sucesso = false;
                result.Mensagem = "preencha o nome";
            }
            else if (request.Sobrenome == "")
            {
                result.Sucesso = false;
                result.Mensagem = "preencha o sobrenome";
            }
            else if (request.Email == "")
            {
                result.Sucesso = false;
                result.Mensagem = "preencha o E-mail";
            }
            else if (request.Telefone == "")
            {
                result.Sucesso = false;
                result.Mensagem = "preencha o telefone";
            }
            else if (request.Senha == "")
            {
                result.Sucesso = false;
                result.Mensagem = "preencha a senha";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("cursoRenatoGavaDb");

                var usuarioService = new UsuarioService(connectionString);
                result = usuarioService.Cadastro(request.Nome, request.Sobrenome, request.Email, request.Telefone, request.Senha, request.Genero);
            }

            return result;
        }


        [Route("esqueceuSenha")]
        [HttpPost]
        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if (request == null)
            {
                result.Sucesso = false;
                result.Mensagem = "request = null";
            }
            else if (request.Email == "")
            {
                result.Sucesso = false;
                result.Mensagem = "preencha o campo E-mail";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("cursoRenatoGavaDb");

                var usuarioService = new UsuarioService(connectionString);
                result = usuarioService.esqueceuSenha(request.Email);
            }

            return result;
        }


        [Route("obterUsuario")]
        [HttpGet]

        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.Mensagem = "Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("cursoRenatoGavaDb");

                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.Mensagem = "usuario não existe";
                }
                else
                {
                    result.Sucesso = true;
                    result.Nome = usuario.Nome;
                }
            }

                return result;
        }
    }
}
