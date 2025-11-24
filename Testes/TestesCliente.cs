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
        FuncoesCliente funcoes;
        Faker faker;

        public List<string> nomes;
        public List<string> enderecos;
        public List<string> cpfs;

        public TestesCliente()
        {
            funcoes = new FuncoesCliente();
            faker = new Faker();

            nomes = Enumerable.Range(0, 10)
                .Select(i => faker.Name.FullName())
                .ToList();
            enderecos = Enumerable.Range(0, 10)
                .Select(i => faker.Person.Address.Street)
                .ToList();
            cpfs = Enumerable.Range(0, 10)
                .Select(i => faker.Person.Cpf())
                .ToList();
        }

        [Fact(DisplayName = "Testar cadastro sem campos nulos")]
        public void testarCadastroSucesso()
        {
            for(int i = 0; i < 10; i++)
            {
                Cliente clienteTeste = funcoes.CadastrarCliente(this.nomes[i], enderecos[i], cpfs[i]);
                Assert.NotNull(clienteTeste);
            }

            Console.WriteLine("Teste passou com sucesso!");
        }

        [Fact(DisplayName = "Testar cadastro com campo(s) nulo(s)")]
        public void testarCadastroFracasso()
        {
            string nome = faker.Person.FullName.OrNull(faker, 0.5f);
            string endereco = faker.Person.Address.Street.OrNull(faker, 0.5f);
            string cpf = faker.Person.Cpf().OrNull(faker, 1f);

            Cliente clienteTeste = funcoes.CadastrarCliente(nome, endereco, cpf);

            Assert.NotNull(clienteTeste);
        }

        [Fact(DisplayName = "Testar CPF menor que 14 caracteres")]
        public void testarCpfInvalido()
        {
            string cpf = faker.Person.Cpf().Remove(2, 4);

            Cliente clienteTeste = funcoes.CadastrarCliente(this.nomes[0], this.enderecos[0], cpf);

            Assert.NotNull(clienteTeste);
        }
    }
}