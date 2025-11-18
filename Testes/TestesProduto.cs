using Fase5.Classes;
using Fase5.Services;
using Bogus;
using Xunit;
using Assert = Xunit.Assert;

namespace Fase5.Testes
{
    public class TestesProduto
    {
        FuncoesProduto funcoes = new FuncoesProduto();

        public List<Produto> ListaProdutosFakesCertos()
        {
            var produtoFaker = new Faker<Produto>("pt_BR")
                .RuleFor(c => c.nomeProduto, f => f.Commerce.Product())
                .RuleFor(c => c.QuantidadeEstoque, f => f.Random.Number(1, 500))
                .RuleFor(c => c.categoria, f => f.Random.Word())
                .RuleFor(c => c.descricao, f => f.Random.Words(6))
                .RuleFor(c => c.preco, f => double.Parse(f.Commerce.Price()));

            var produtos = produtoFaker.Generate(10);

            return produtos;
        }

        public List<Produto> ListaProdutosFakesErrados()
        {
            var produtoFaker = new Faker<Produto>("pt_BR")
                .RuleFor(c => c.nomeProduto, f => f.Commerce.Product().OrNull(f, .1f))
                .RuleFor(c => c.QuantidadeEstoque, f => f.Random.Number(1, 500).OrNull(f, .1f))
                .RuleFor(c => c.categoria, f => f.Random.Word().OrNull(f, .1f))
                .RuleFor(c => c.descricao, f => f.Random.Words(6).OrNull(f, .1f))
                .RuleFor(c => c.preco, f => f.Random.Double(1.0, 1500.0).OrNull(f, .1f));

            var produtosErrados = produtoFaker.Generate(10);

            return produtosErrados;
        }

        public Produto produtoQuantidadesErradas()
        {
            var produtoFaker = new Faker<Produto>("pt_BR")
                .RuleFor(c => c.nomeProduto, f => f.Commerce.Product())
                .RuleFor(c => c.QuantidadeEstoque, f => f.Random.Number(-1, 1))
                .RuleFor(c => c.categoria, f => f.Random.Word())
                .RuleFor(c => c.descricao, f => f.Random.Words(6))
                .RuleFor(c => c.preco, f => f.Random.Double(-1, 1));

            var produtoErrado = produtoFaker.Generate(1)[0];
            return produtoErrado;
        }

        [Fact(DisplayName = "Verificar se os campos não são nulos / Sucesso")]
        public void testarProdutosSucesso()
        {
            List<Produto> produtos = ListaProdutosFakesCertos();

            foreach(var produto in produtos)
            {
                Assert.False(string.IsNullOrWhiteSpace(produto.nomeProduto));
                Assert.NotNull(produto.QuantidadeEstoque);
                Assert.False(string.IsNullOrWhiteSpace(produto.categoria));
                Assert.False(string.IsNullOrWhiteSpace(produto.descricao));
                Assert.NotNull(produto.QuantidadeEstoque);
            }
        }

        [Fact(DisplayName = "Verificar se os campos não são nulos / Fracasso")]
        public void testarProdutosFracasso()
        {
            List<Produto> produtos = ListaProdutosFakesErrados();

            foreach (var produto in produtos)
            {
                Assert.False(string.IsNullOrWhiteSpace(produto.nomeProduto));
                Assert.NotNull(produto.QuantidadeEstoque);
                Assert.False(string.IsNullOrWhiteSpace(produto.categoria));
                Assert.False(string.IsNullOrWhiteSpace(produto.descricao));
                Assert.NotNull(produto.preco);
            }
        }

        [Fact(DisplayName = "Verificar se o preço é maior que zero ou é um valor inválido / fracasso")]
        public void testarQuantidadeNegativaFracasso()
        {
            Produto produto = produtoQuantidadesErradas();

            Assert.False(produto.QuantidadeEstoque > 0);
            Assert.False(produto.preco > 0);
        }

        [Fact(DisplayName = "Verificar se desconto está sendo aplicado corretamente / Sucesso")]
        public void TesteCalculoDesconto()
        {
            Random random = new Random();

            List<Produto> produtos = ListaProdutosFakesCertos();
            List<int> descontos = new List<int> { 10, 19, 32, 5, 8, 2, 50, 35, 21, 15};
            
            foreach(Produto produto in produtos)
            {
                for(int i = 0; i < descontos.Count(); i++)
                {
                    Assert.Equal(funcoes.AplicarDesconto(produto, descontos[i]).preco, produto.preco - (descontos[i] / 100 * produto.preco));
                }
            }
        }
    }
}