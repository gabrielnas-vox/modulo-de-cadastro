using Fase5.Classes;
using Fase5.Services;

FuncoesMenu menu = new FuncoesMenu();

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
    }
}