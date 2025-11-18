using Fase5.Classes;
using Fase5.Services;
using Bogus;
using Xunit;
using Assert = Xunit.Assert;

namespace Fase5.Testes
{
    public class TestesUsuario
    {
        FuncoesUsuario funcoes = new FuncoesUsuario();

        public List<Usuario> ListaUsuariosFakesCertos()
        {
            var usuarioFaker = new Faker<Usuario>("pt_BR")
                .RuleFor(c => c.Email, f => f.Internet.Email(f.Person.FirstName))
                .RuleFor(c => c.Senha, f => f.Random.Number(100000000, 2000000000).ToString())
                .RuleFor(c => c.username, f => f.Person.FirstName);

            var usuarios = usuarioFaker.Generate(10);

            usuarios.ForEach(u => Console.WriteLine(u.Email));

            return usuarios;
        }

        public List<Usuario> ListaUsuariosFakesErrados()
        {
            var usuarioFaker = new Faker<Usuario>("pt_BR")
                .RuleFor(c => c.Email, f => f.Internet.Email(f.Person.FirstName).OrNull(f, .1f))
                .RuleFor(c => c.Senha, f => f.Random.Number(1000000, 20000000).ToString().OrNull(f, .1f))
                .RuleFor(c => c.username, f => f.Person.FirstName.OrNull(f, .1f));

            var usuarios = usuarioFaker.Generate(10);

            usuarios.ForEach(u => Console.WriteLine(u.Email));

            return usuarios;
        }

        [Fact]
        public void testarCadastroSucesso()
        {
            List<Usuario> lista = ListaUsuariosFakesCertos();

            foreach (var usuario in lista)
            {
                Assert.False(string.IsNullOrWhiteSpace(usuario.Email));

                Assert.False(string.IsNullOrWhiteSpace(usuario.Senha));
                Assert.False(usuario.Senha.Count() < 8, $"A senha precisa ser maior que 8 caracteres");

                Assert.False(string.IsNullOrWhiteSpace(usuario.username));
            }
        }

        [Fact]
        public void testarCadastroFalho()
        {
            List<Usuario> lista = ListaUsuariosFakesErrados();

            foreach (var usuario in lista)
            {
                Assert.False(string.IsNullOrWhiteSpace(usuario.Email));

                Assert.False(string.IsNullOrWhiteSpace(usuario.Senha));
                Assert.False(usuario.Senha.Count() < 8, $"A senha precisa ser maior que 8 caracteres");

                Assert.False(string.IsNullOrWhiteSpace(usuario.username));
            }
        }
    }
}