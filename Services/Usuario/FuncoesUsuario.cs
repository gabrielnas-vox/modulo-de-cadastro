using Fase5.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Fase5.Services
{
    internal class FuncoesUsuario
    {
        private int idAtual = 0;

        [TestMethod]
        public Usuario cadastro(string email, string senha, string username)
        {
            if(email == null || senha == null || username == null)
            {
                Console.WriteLine("Você deve preencher todos os campos.");

                return null;
            }

            if(senha.Length < 8)
            {
                Console.WriteLine("A senha deve conter no mínimo 8 caracteres!");

                return null;
            }

            Usuario usuarioCadastrado = new Usuario(idAtual++, email, senha, username);
            return usuarioCadastrado;
        }
    }
}