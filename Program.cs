using Fase5.Classes;
using Fase5.Services;
using Fase5.Testes;
using System.Collections.Generic;

FuncoesMenu menu = new FuncoesMenu();

TestesUsuario testeUsuario = new TestesUsuario();
TestesProduto testeProduto = new TestesProduto();
TestesCliente testesCliente = new TestesCliente();

// Teste que realiza com sucesso
// testeUsuario.testarCadastroSucesso();
// testeProduto.testarProdutosSucesso();
// testesCliente.testarCadastroSucesso();
testeProduto.TesteCalculoDesconto();

// Teste que falha
// testeUsuario.testarCadastroFalho();
// testeProduto.testarQuantidadeNegativaFracasso();
// testesCliente.testarCadastroFracasso();
// testesCliente.testarCpfInvalido();

int opcao;

while(true)
{
    Console.WriteLine("==================");
    Console.WriteLine("1 - Cadastrar-se");
    Console.WriteLine("2 - Fazer login");
    Console.WriteLine("3 - Fazer logout");

    Console.WriteLine("");

    Console.WriteLine("4 - Cadastrar cliente");
    Console.WriteLine("5 - Cadastrar produto");
    Console.WriteLine("6 - Gerar pedido");

    Console.WriteLine("");

    Console.WriteLine("7 - Visualizar clientes");
    Console.WriteLine("8 - Visualizar produtos");
    Console.WriteLine("9 - Deletar produto(s)");
    Console.WriteLine("==================");

    opcao = int.Parse(Console.ReadLine());

    switch(opcao)
    {
        case 1:
            menu.cadastroUsuario();
            break;
        case 2:
            menu.fazerLogin();
            break;
        case 3:
            menu.logout();
            break;
        case 4:
            menu.cadastroCliente();
            break;
        case 5:
            menu.cadastroProduto();
            break;
        case 6:
            menu.cadastroPedido();
            break;
        case 7:
            menu.listarClientes();
            break;
        case 8:
            menu.listarProdutos();
            break;
        case 9:
            menu.deletarProduto();
            break;
    }
}