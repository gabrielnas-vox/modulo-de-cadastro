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
            if(nome == null || quantidadeEstoque == null || categoria == null || descricao == null || preco == null)
            {
                Console.WriteLine("Por favor, preencha todos os campos para cadastrar o produto em sistema");
                return null;
            } else if(quantidadeEstoque < 0 || preco < 0)
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

        [TestMethod]
        public void DeletarProdutoPorID(List<Produto> produtos, int id)
        {
            if(produtos.Count > 0)
            {
                bool encontrado = false;

                for(int i = 0; i < produtos.Count; i++)
                {
                    if (produtos[i].Id == id)
                    {
                        produtos.Remove(produtos[i]);
                        encontrado = true;
                    }
                }

                string resultado = encontrado == true ? "O registro foi encontrado e apagado" : "Não foi encontrado nenhum registro com esse ID";
                Console.WriteLine(resultado);

            } else
            {
                Console.WriteLine("Não há quaisquer produtos cadastrados em sistema");
            }
        }

        [TestMethod]
        public void DeletarProdutoPorNome(List<Produto> produtos, string nome)
        {
            if(produtos.Count > 0)
            {
                produtos.RemoveAll(produto => produto.nomeProduto.Contains(nome));

                Console.WriteLine($"Foram removidos os produtos de nome {nome}!");

            } else
            {
                Console.WriteLine("Não há produto(s) cadastrado(s) no sistema!");
            }
        }

        [TestMethod]
        public Produto AplicarDesconto(Produto produto, double desconto)
        {
            // modo 1: aplicar desconto no preço do produto | modo 2: aplicar desconto de atacado pro cliente em específico

            double valorComDesconto = produto.preco * (desconto / 100);

            Console.WriteLine($"O produto {produto.nomeProduto} recebeu um desconto de {desconto}%, passando de {produto.preco} para {valorComDesconto}");

            produto.preco = produto.preco - valorComDesconto;
            return produto;
        }
    }
}