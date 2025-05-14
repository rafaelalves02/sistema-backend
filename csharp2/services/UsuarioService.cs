using csharp2.common;
using csharp2.entities;
using csharp2.models;
using csharp2.repositories;

namespace csharp2.services
{
    public class UsuarioService
    {
        private string _connectionString;
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.ObterPorEmail(email);

            if (usuario != null)
            {
                //usuario existe
                if (usuario.Senha == senha)
                {
                    //senha válida
                    result.Sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //senha inválida
                    result.Sucesso = false;
                    result.Mensagem = "Usuario ou senha inválidos";
                }
            }
            else
            {
                //usuario não existe
                result.Sucesso = false;
                result.Mensagem = "Usuario ou senha inválidos";
            }

                return result;
        }

        public CadastroResult Cadastro(string Nome, string Sobrenome, string Email, string Telefone, string Senha, string Genero)
        {
            var result = new CadastroResult();
             
            var UsuarioRepository = new UsuarioRepository(_connectionString);

            var Usuario = UsuarioRepository.ObterPorEmail(Email);

            if (Usuario != null)
            {
                //usuario já existente
                result.Sucesso = false;
                result.Mensagem = "usuario já existente";
            }
            else
            {
                //usuario não existente
                var usuario = new Usuario();

                usuario.Nome = Nome;
                usuario.Sobrenome = Sobrenome;
                usuario.Email = Email;
                usuario.Telefone = Telefone;
                usuario.Genero = Genero;
                usuario.Senha = Senha;
                usuario.UsuarioGuid = Guid.NewGuid();

                var affectedRows = UsuarioRepository.Inserir(usuario);

                if (affectedRows > 0)
                {
                    //cadasstrou
                    result.Sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                    result.Mensagem = "cadastro realizado com sucesso!";
                }
                else
                {
                    //houve um erro ao cadastrar 
                    result.Sucesso = false;
                    result.Mensagem = "houve um erro ao cadastrar";
                }
            }



            return result;
        }

        public EsqueceuSenhaResult esqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var UsuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = UsuarioRepository.ObterPorEmail(email);

            if (usuario != null)
            {
                //usuario existe
                var emailSender = new EmailSender();

                var assunto = "recuperaçao de senha";
                var corpo = "sua senha é" + usuario.Senha;
                var emailDeDestino = usuario.Email;

                emailSender.EnviarEmail(assunto, corpo, emailDeDestino);
            }
            else
            {
                //usuario não existe
                result.Sucesso = false;
                result.Mensagem = "usuario não existente";
            }

                return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}
