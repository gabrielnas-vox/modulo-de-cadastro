using Fase5.Classes;
using Fase5.Services;
using Bogus;
using Xunit;
using Assert = Xunit.Assert;
using Bogus.Extensions.Denmark;
using Bogus.Extensions.Brazil;

namespace Fase5.Testes
{
    public class TestesPedido
    {
        FuncoesPedido funcoes;
        TestesCliente testesCliente = new TestesCliente();
        TestesProduto testesProduto = new TestesProduto();
        Faker faker;

        FuncoesCliente funcoesCliente = new FuncoesCliente();
        FuncoesProduto funcoesProduto = new FuncoesProduto();

        List<DateOnly> estimativa;
        List<string> formaPagamento;
        List<Cliente> clientes = new List<Cliente>();
        List<Produto> produtos = new List<Produto>();

        public TestesPedido()
        {
            funcoes = new FuncoesPedido();
            faker = new Faker();

            estimativa = Enumerable.Range(0, 10)
                .Select(i => faker.Date.FutureDateOnly())
                .ToList();
            formaPagamento = Enumerable.Range(0, 10)
                .Select(i => faker.Person.FirstName)
                .ToList();

            for(int i = 0; i < 10; i++)
            {
                clientes.Add(this.funcoesCliente.CadastrarCliente(testesCliente.nomes[i], testesCliente.enderecos[i],
                    testesCliente.cpfs[i]
                ));
            }

            for (int i = 0; i < 10; i++)
            {
                produtos.Add(this.funcoesProduto.CriarProduto(testesProduto.nome[i], testesProduto.quantidade[i], 
                    testesProduto.categoria[i], testesProduto.descricao[i], testesProduto.preco[i])
                );
            }
        }

        [Fact(DisplayName = "Testar pedido sem campos nulos e inválidos")]
        public void testarCadastroSucesso()
        {
            for(int i = 0; i < 10; i++)
            {
                Pedido pedidoTeste = funcoes.gerarPedido(clientes[i], produtos[i], estimativa[i], formaPagamento[i]);
                Assert.NotNull(pedidoTeste);
            }

            Console.WriteLine("Teste passou com sucesso!");
        }

        [Fact(DisplayName = "Testar cadastro com campo(s) nulo(s)")]
        public void testarCadastroFracasso()
        {
            Cliente cliente = clientes[0].OrNull(faker, 0.5f);
            Produto produto = produtos[0].OrNull(faker, 0.5f);
            string formaPagamento = this.formaPagamento[0].OrNull(faker, 0.5f);

            if(cliente != null && produto != null && formaPagamento != null)
            {
                formaPagamento = null;
            }

            Pedido pedidoErrado = funcoes.gerarPedido(cliente, produto, this.estimativa[0], formaPagamento);

            Assert.NotNull(pedidoErrado);
        }

        //[Fact(DisplayName = "Testar CPF menor que 14 caracteres")]
        //public void testarCpfInvalido()
        //{
        //    string cpf = faker.Person.Cpf().Remove(2, 4);

        //    Cliente clienteTeste = funcoes.CadastrarCliente(this.nomes[0], this.enderecos[0], cpf);

        //    Assert.NotNull(clienteTeste);
        //}
    }
}