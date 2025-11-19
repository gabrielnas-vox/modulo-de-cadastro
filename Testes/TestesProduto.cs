using Bogus;
using Bogus.DataSets;
using Fase5.Classes;
using Fase5.Services;
using Xunit;
using Assert = Xunit.Assert;

namespace Fase5.Testes
{
    public class TestesProduto
    {
        FuncoesProduto funcoes = new FuncoesProduto();
        Faker faker;

        List<string> nome;
        List<int> quantidade;
        List<string> categoria;
        List<string> descricao;
        List<double> preco;

        public TestesProduto()
        {
            funcoes = new FuncoesProduto();
            faker = new Faker();

            nome = Enumerable.Range(0, 10)
                .Select(i => faker.Commerce.ProductName())
                .ToList();
            quantidade = Enumerable.Range(0, 10)
                .Select(i => faker.Random.Number(0, 500))
                .ToList();
            categoria = Enumerable.Range(0, 10)
                .Select(i => faker.Commerce.ProductAdjective())
                .ToList();
            descricao = Enumerable.Range(0, 10)
                .Select(i => faker.Commerce.ProductDescription())
                .ToList();
            preco = Enumerable.Range(0, 10)
                .Select(i => double.Parse(faker.Commerce.Price()))
                .ToList();
        }

        [Fact(DisplayName = "Testar cadastro do produto sem campos nulos")]
        public void cadastrarProdutosSucesso()
        {
            for (int i = 0; i < 10; i++)
            {
                Produto produtoTeste = funcoes.CriarProduto(this.nome[i], 
                    this.quantidade[i], 
                    this.categoria[i],
                    this.descricao[i],
                    this.preco[i]);
                Assert.NotNull(produtoTeste);
            }

            Console.WriteLine("Teste passou com sucesso!");
        }

        [Fact(DisplayName = "Verificar se os campos não são nulos / Fracasso")]
        public void cadastrarProdutoFracasso()
        {
            string nome = faker.Commerce.ProductName().OrNull(faker, 0.33f);
            int quantidade = faker.Random.Number(0, 500);
            string categoria = faker.Commerce.ProductAdjective().OrNull(faker, 0.33f);
            string descricao = faker.Commerce.ProductDescription().OrNull(faker, 1f);
            double preco = double.Parse(faker.Commerce.Price());

            Produto produtoTeste = funcoes.CriarProduto(nome, quantidade, categoria, descricao, preco);

            Assert.NotNull(produtoTeste);
        }

        [Fact(DisplayName = "Testar preço ou quantidade negativos")]
        public void testarQuantidadeNegativaFracasso()
        {
            int quantidade = faker.Random.Number(-1, 0);
            double preco = Convert.ToDouble(faker.Random.Number(-1, 0));

            if(quantidade == 0 && preco == 0)
            {
                preco = -1337;
            }

            Produto produtoTeste = funcoes.CriarProduto(this.nome[0], quantidade, this.categoria[0], this.descricao[0], preco);

            Assert.NotNull(produtoTeste);
        }

        [Fact(DisplayName = "Verificar se desconto está sendo aplicado corretamente / Sucesso")]
        public void TesteCalculoDesconto()
        {
            Random random = new Random();
        
            var produtoFaker = new Faker<Produto>("pt_BR")
                .RuleFor(c => c.nomeProduto, f => f.Commerce.Product())
                .RuleFor(c => c.QuantidadeEstoque, f => f.Random.Number(1, 500))
                .RuleFor(c => c.categoria, f => f.Random.Word())
                .RuleFor(c => c.descricao, f => f.Random.Words(6))
                .RuleFor(c => c.preco, f => double.Parse(f.Commerce.Price()));

            List<Produto> produtos = produtoFaker.Generate(10);
            List<int> descontos = new List<int> { 10, 19, 32, 5, 8, 2, 50, 35, 21, 15 };

            foreach (Produto produto in produtos)
            {
                for (int i = 0; i < descontos.Count(); i++)
                {
                    Assert.Equal(funcoes.AplicarDesconto(produto, descontos[i]).preco, produto.preco - (descontos[i] / 100 * produto.preco));
                }
            }
        }
    }
}