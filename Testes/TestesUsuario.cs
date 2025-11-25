using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using Fase5.Classes;
using Fase5.Services;
using Xunit;
using Assert = Xunit.Assert;

namespace Fase5.Testes
{
    public class TestesUsuario
    {
        FuncoesUsuario funcoes = new FuncoesUsuario();
        Faker faker;

        List<string> email;
        List<string> senha;
        List<string> username;

        public TestesUsuario()
        {
            funcoes = new FuncoesUsuario();
            faker = new Faker();

            email = Enumerable.Range(0, 10)
                .Select(i => faker.Person.Email)
                .ToList();
            senha = Enumerable.Range(0, 10)
                .Select(i => faker.Internet.Password())
                .ToList();
            username = Enumerable.Range(0, 10)
                .Select(i => faker.Person.UserName)
                .ToList();
        }

        [Fact(DisplayName = "Testar cadastros sem campos nulos")]
        public void testarCadastroSucesso()
        {
            for (int i = 0; i < 10; i++)
            {
                Usuario usuarioTeste = funcoes.cadastro(this.email[i], senha[i], username[i]);
                Assert.NotNull(usuarioTeste);
            }

            Console.WriteLine("Teste passou com sucesso!");
        }

        [Fact(DisplayName = "Testar cadastro com campo(s) nulo(s)")]
        public void testarCadastroFalho()
        {
            string email = faker.Person.Email.OrNull(faker, 0.5f);
            string senha = faker.Internet.Password().OrNull(faker, 0.5f);
            string username = faker.Person.UserName.OrNull(faker, 0.5f);

            if(email != null && senha != null && username != null)
            {
                username = null;
            }

            Usuario usuarioTeste = funcoes.cadastro(email, senha, username);

            Assert.NotNull(usuarioTeste);
        }

        [Fact(DisplayName = "Testar senha menor que 8 caracteres")]
        public void testarSenhaMenorQue8Chars()
        {
            int tamanho = faker.Random.Number(1, 7);
            string senha = faker.Internet.Password(tamanho);

            Usuario usuarioTeste = funcoes.cadastro(this.email[0], senha, this.username[0]);

            Assert.NotNull(usuarioTeste);
        }
    }
}