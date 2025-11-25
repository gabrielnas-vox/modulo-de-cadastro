using Fase5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5.Services
{
    public class FuncoesProduto
    {
        private int idAtual = 0;

        [TestMethod]
        public Produto CriarProduto(string nome, int quantidadeEstoque, string categoria, string descricao, double preco)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(categoria) || string.IsNullOrWhiteSpace(descricao))
            {
                Console.WriteLine("Por favor, preencha todos os campos para cadastrar o produto em sistema");
                return null;
            }
            else if (quantidadeEstoque < 0 || preco < 0)
            {
                Console.WriteLine("Você digitou um valor errado para quantidade em estoque ou preço. Por favor, revise os campos.");
                return null;
            }

            Produto novoProduto = new Produto(
                idAtual++,
                nome,
                quantidadeEstoque,
                categoria,
                descricao,
                preco
            );

            return novoProduto;
        }

        // Remove da lista o produto cujo Id corresponda ao valor informado.
        // Comportamento:
        // - Se a lista estiver vazia, nenhuma remoção é realizada e uma mensagem é exibida no console.
        // - Caso um produto com o ID especificado seja encontrado, ele é removido e uma mensagem de sucesso é exibida.
        // - Caso contrário, é exibida uma mensagem informando que nenhum registro foi encontrado para o ID informado.
        // Pré-condição: a lista "produtos" não deve ser nula.
        // Exemplo de uso:
        // var lista = new List<Produto> { new Produto(1, "Mouse",10, "Periférico", "Mouse óptico",50) };
        // new FuncoesProduto().DeletarProdutoPorID(lista,1);
        // Após a chamada: lista.Count ==0
        [TestMethod]
        public void DeletarProdutoPorID(List<Produto> produtos, int id)
        {
            if (produtos.Count > 0)
            {
                bool encontrado = false;

                for (int i = 0; i < produtos.Count; i++)
                {
                    if (produtos[i].Id == id)
                    {
                        produtos.Remove(produtos[i]);
                        encontrado = true;
                    }
                }

                string resultado = encontrado == true ? "O registro foi encontrado e apagado" : "Não foi encontrado nenhum registro com esse ID";
                Console.WriteLine(resultado);

            }
            else
            {
                Console.WriteLine("Não há quaisquer produtos cadastrados em sistema");
            }
        }

        [TestMethod]
        public void DeletarProdutoPorNome(List<Produto> produtos, string nome)
        {
            if (produtos.Count > 0)
            {
                produtos.RemoveAll(produto => produto.nomeProduto.Contains(nome));

                Console.WriteLine($"Foram removidos os produtos de nome {nome}!");

            }
            else
            {
                Console.WriteLine("Não há produto(s) cadastrado(s) no sistema!");
            }
        }

        [TestMethod]
        public Produto AplicarDesconto(Produto produto, double desconto)
        {
            // modo1: aplicar desconto no preço do produto | modo2: aplicar desconto de atacado pro cliente em específico

            double valorComDesconto = produto.preco * (desconto / 100);

            Console.WriteLine($"O produto {produto.nomeProduto} recebeu um desconto de {desconto}%, passando de R${Math.Round(produto.preco)} para R${Math.Round(produto.preco - valorComDesconto)}");

            produto.preco = produto.preco - valorComDesconto;
            return produto;
        }
    }
}