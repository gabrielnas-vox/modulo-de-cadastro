using Fase5.Classes;
using Fase5.Services;
using Bogus;
using Xunit;
using Assert = Xunit.Assert;

namespace Fase5.Testes
{
    internal class TestesUsuario
    {
        FuncoesUsuario funcoes = new FuncoesUsuario();

        public List<Usuario> ListaUsuariosFakes()
        {
            var usuarioFaker = new Faker<Usuario>("pt_BR")
                .RuleFor(c => c.Email, f => f.Internet.Email(f.Person.FirstName))
                .RuleFor(c => c.Senha, f => f.Person.LastName)
                .RuleFor(c => c.Username, f => f.Person.FirstName);

            var usuarios = usuarioFaker.Generate(10);

            usuarios.ForEach(u => Console.WriteLine(u.Email));

            return usuarios;
        }

        [Fact]
        public void testarCadastro()
        {
            List<Usuario> lista = ListaUsuariosFakes();

            foreach (var usuario in lista)
            {
                Assert.NotNull(usuario.Email);
            }
        }
    }
}