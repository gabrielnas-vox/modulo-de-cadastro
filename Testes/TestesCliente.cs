using Fase5.Classes;
using Fase5.Services;
using Bogus;
using Xunit;
using Assert = Xunit.Assert;
using Bogus.Extensions.Denmark;
using Bogus.Extensions.Brazil;

namespace Fase5.Testes
{
    public class TestesCliente
    {
        FuncoesCliente funcoes = new FuncoesCliente();

        public List<Cliente> ListaClientesFakesCertos()
        {
            var usuarioFaker = new Faker<Cliente>("pt_BR")
                .RuleFor(c => c.Nome, f => f.Person.FullName)
                .RuleFor(c => c.Endereco, f => f.Person.Address.Street)
                .RuleFor(c => c.Cpf, f => f.Person.Cpf());

            var usuarios = usuarioFaker.Generate(10);

            usuarios.ForEach(c => Console.WriteLine(c.Nome + c.Endereco + c.Cpf));

            return usuarios;
        }

        public List<Cliente> ListaClientesFakesErrados()
        {
            var usuarioFaker = new Faker<Cliente>("pt_BR")
                .RuleFor(c => c.Nome, f => f.Person.FullName.OrNull(f, .1f))
                .RuleFor(c => c.Endereco, f => f.Person.Address.Street.OrNull(f, .1f))
                .RuleFor(c => c.Cpf, f => f.Person.Cpf().OrNull(f, .1f));

            var usuarios = usuarioFaker.Generate(10);

            usuarios.ForEach(c => Console.WriteLine(c.Nome + c.Endereco + c.Cpf));

            return usuarios;
        }

        [Fact(DisplayName = "Testar cadastro sem campos nulos")]
        public void testarCadastroSucesso()
        {
            List<Cliente> lista = ListaClientesFakesCertos();

            foreach (var cliente in lista)
            {
                Assert.NotNull(cliente.Nome);
                Assert.NotNull(cliente.Endereco);
                Assert.NotNull(cliente.Cpf);
            }
        }

        [Fact(DisplayName = "Testar cadastro com campo(s) nulo(s)")]
        public void testarCadastroFracasso()
        {
            List<Cliente> lista = ListaClientesFakesErrados();

            foreach (var cliente in lista)
            {
                Assert.NotNull(cliente.Nome);
                Assert.NotNull(cliente.Endereco);
                Assert.NotNull(cliente.Cpf);
            }
        }
    }
}