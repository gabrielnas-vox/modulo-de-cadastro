using Fase5.Classes;
using Fase5.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5.Services
{
    internal class FuncoesMenu
    {
        FuncoesCliente funcoesCliente = new FuncoesCliente();
        FuncoesProduto funcoesProduto = new FuncoesProduto();
        FuncoesPedido funcoesPedido = new FuncoesPedido();
        FuncoesUsuario funcoesUsuario = new FuncoesUsuario();

        List<Cliente> clientesCadastrados = new List<Cliente>();
        List<Produto> produtosCadastrados = new List<Produto>();
        List<Pedido> pedidosCadastrados = new List<Pedido>();
        Usuario dadosCadastro = new Usuario();
        Login dadosLogin;

        string nome; // esse nome serve para todas as entidades

        // váriaveis para cadastro e login do USUÁRIO
        string email;
        string senha;
        bool estaLogado = false;

        // Variáveis para cadastro do CLIENTE
        string endereco;
        string cpf;

        // Variáveis para cadastro do PRODUTO
        int quantidadeEstoque;
        string categoria;
        string descricao;

        // Variáveis para cadastro do PEDIDO
        int clienteQueComprou;
        int produtoComprado;
        DateOnly estimativaEntrega;
        string formaPagamento;

        public void cadastroUsuario()
        {
            bool? cadastrado = null;

            while(cadastrado == null)
            {
                Console.WriteLine("Informe seu nome de usuário: ");
                this.nome = Console.ReadLine();

                Console.WriteLine("Informe seu e-mail: ");
                this.email = Console.ReadLine();

                Console.WriteLine("Informe sua senha: ");
                this.senha = Console.ReadLine();

                dadosCadastro = funcoesUsuario.cadastro(email, senha, nome);

                if(dadosCadastro.Email != null)
                {
                    cadastrado = true;
                }
            }
        
        }

        public void fazerLogin()
        {
            if(!estaLogado)
            {
                Console.WriteLine("Informe seu e-mail: ");
                this.email = Console.ReadLine();

                Console.WriteLine("Informe sua senha: ");
                this.senha = Console.ReadLine();

                dadosLogin = funcoesUsuario.login(new Login(this.email, this.senha), new Login(dadosCadastro.Email, dadosCadastro.Senha));

                if(dadosLogin != null)
                {
                    estaLogado = true;
                }
            } else
            {
                Console.WriteLine("Você já está logado. Se deseja entrar com uma conta diferente, selecione a opção 3 e faça o logout.");
            }
        }

        public void cadastroCliente()
        {
            Console.WriteLine("Qual é o nome do cliente: ");
            this.nome = Console.ReadLine();

            Console.WriteLine("Qual é o endereço do cliente: ");
            this.endereco = Console.ReadLine();

            Console.WriteLine("Qual é o CPF do cliente: ");
            this.cpf = Console.ReadLine();

            clientesCadastrados.Add(
                funcoesCliente.CadastrarCliente(this.nome, this.endereco, this.cpf)
            );

            Console.WriteLine("Cliente novo cadastrado!");
        }

        public void cadastroProduto()
        {
            Console.WriteLine("Digite o nome do produto: ");
            nome = Console.ReadLine();

            Console.WriteLine("Quantos deste produto tem em estoque: ");
            quantidadeEstoque = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a categoria do produto (Eletrodoméstico, higiene, aparelho...): ");
            categoria = Console.ReadLine();

            Console.WriteLine("Digite a descrição do produto: ");
            descricao = Console.ReadLine();

            produtosCadastrados.Add(
                funcoesProduto.CriarProduto(nome, quantidadeEstoque, categoria, descricao)
            );
        }

        public void cadastroPedido()
        {
            Console.WriteLine("-- Gerar pedido de compra --");

            this.listarClientes();

            Console.Write("Selecione o ID do cliente: ");
            this.clienteQueComprou = int.Parse(Console.ReadLine());

            Console.Write("Selecione o ID do produto: ");
            this.produtoComprado = int.Parse(Console.ReadLine());

            Console.Write("Qual será a estimativa de entrega (Ano/Mês/dias): ");
            this.estimativaEntrega = DateOnly.Parse(Console.ReadLine());

            Console.Write("Qual será a forma de pagamento: ");
            this.formaPagamento = Console.ReadLine();

            pedidosCadastrados.Add(funcoesPedido.gerarPedido(
                this.clientesCadastrados[clienteQueComprou],
                this.produtosCadastrados[produtoComprado],
                this.estimativaEntrega,
                this.formaPagamento
            ));
        }

        public void listarClientes()
        {
            Console.WriteLine("-- Lista de clientes cadastrados e seus pedidos --");
            for (int i = 0; i < this.clientesCadastrados.Count(); i++)
            {
                Console.WriteLine(
                    "===\n" +
                    $"Id do cliente: {i}\n" +
                    $"Nome: {this.clientesCadastrados[i].Nome}\n" +
                    $"Endereço: {this.clientesCadastrados[i].Endereco}\n" +
                    $"Endereço: {this.clientesCadastrados[i].Cpf}\n" +
                    "===\n"
                );
            }
        }

        public void listarProdutos()
        {
            Console.WriteLine("-- Produtos cadastrados no sistema --");
            for (int i = 0; i < this.produtosCadastrados.Count(); i++)
            {
                Console.WriteLine(
                    "===\n" +
                    $"Id do produto: {i}\n" +
                    $"Produto: {this.produtosCadastrados[i].NomeProduto}\n" +
                    $"Quantidade disponível em estoque: {this.produtosCadastrados[i].QuantidadeEstoque}\n" +
                    $"Categoria: {this.produtosCadastrados[i].Categoria}\n" +
                    $"Descrição detalhada do produto: {this.produtosCadastrados[i].Descricao}\n" +
                    "===\n"
                );
            }
        }
    }
}