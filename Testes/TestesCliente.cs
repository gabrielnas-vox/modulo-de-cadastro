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

            var clientes = usuarioFaker.Generate(10);

            clientes.ForEach(c => Console.WriteLine(c.Nome + c.Endereco + c.Cpf));

            return clientes;
        }

        public Cliente ClienteCpfInvalido()
        {
            var usuarioFaker = new Faker<Cliente>("pt_BR")
                .RuleFor(c => c.Nome, f => f.Person.FullName)
                .RuleFor(c => c.Endereco, f => f.Person.Address.Street)
                .RuleFor(c => c.Cpf, f => f.Person.Cpf(false));

            var cliente = usuarioFaker.Generate(1)[0];

            return cliente;
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

        [Fact(DisplayName = "Testar CPF menor que 11 (inválido)")]
        public void testarCpfInvalido()
        {
            Cliente cliente = ClienteCpfInvalido();
            string cpfInvalido = cliente.Cpf.Remove(2, 4);

            Assert.False(cpfInvalido.Count() < 11);
        }
    }
}