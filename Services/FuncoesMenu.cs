using Fase5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5.Services
{
    internal class FuncoesMenu
    {
        public void listarClientes(List<Cliente> clientes)
        {
            Console.WriteLine("-- Lista de clientes cadastrados e seus pedidos --");
            for (int i = 0; i < clientes.Count(); i++)
            {
                Console.WriteLine(
                    "===\n" +
                    $"Id do cliente: {i}\n" +
                    $"Nome: {clientes[i].Nome}\n" +
                    $"Endereço: {clientes[i].Endereco}\n" +
                    $"Endereço: {clientes[i].Cpf}\n" +
                    "===\n"
                );
            }
        }

        public void listarProdutos(List<Produto> produtos)
        {
            Console.WriteLine("-- Produtos cadastrados no sistema --");
            for (int i = 0; i < produtos.Count(); i++)
            {
                Console.WriteLine(
                    "===\n" +
                    $"Id do produto: {i}\n" +
                    $"Produto: {produtos[i].NomeProduto}\n" +
                    $"Quantidade disponível em estoque: {produtos[i].QuantidadeEstoque}\n" +
                    $"Categoria: {produtos[i].Categoria}\n" +
                    $"Descrição detalhada do produto: {produtos[i].Descricao}\n" +
                    "===\n"
                );
            }
        }
    }
}