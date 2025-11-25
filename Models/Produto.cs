namespace Fase5.Classes
{
    public class Produto
    {
        private int idProduto;
        public string nomeProduto;
        private int quantidadeEstoque;
        public string categoria;
        public string descricao;
        public double preco;

        public Produto()
        {

        }

        public Produto(int idProduto, string nomeProduto, int quantidadeEstoque, string categoria, string descricao, double preco)
        {
            this.idProduto = idProduto;
            this.nomeProduto = nomeProduto;
            this.QuantidadeEstoque = quantidadeEstoque;
            this.categoria = categoria;
            this.descricao = descricao;
            this.preco = preco;
        }

        public int Id { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}