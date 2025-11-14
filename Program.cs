using Fase5.Classes;
using Fase5.Services;

FuncoesCliente funcoesCliente = new FuncoesCliente();
FuncoesProduto funcoesProduto = new FuncoesProduto();
FuncoesPedido funcoesPedido = new FuncoesPedido();

List<Cliente> clientesCadastrados = new List<Cliente>();
List<Produto> produtosCadastrados = new List<Produto>();
List<Pedido> pedidosCadastrados = new List<Pedido>();

int opcao;

String nome; // esse nome serve para todas as entidades

String endereco;
String cpf;

while(true)
{
    Console.WriteLine("==================");
    Console.WriteLine("1 - Cadastrar cliente");
    Console.WriteLine("2 - Cadastrar produto");
    Console.WriteLine("3 - Gerar pedido");

    Console.WriteLine("4 - Visualizar clientes");
    Console.WriteLine("5 - Visualizar produtos");
    Console.WriteLine("==================");

    opcao = int.Parse(Console.ReadLine());

    switch(opcao)
    {
        case 1:
            Console.WriteLine("Qual é o nome do cliente: ");
            nome = Console.ReadLine();

            Console.WriteLine("Qual é o endereço do cliente: ");
            endereco = Console.ReadLine();

            Console.WriteLine("Qual é o CPF do cliente: ");
            cpf = Console.ReadLine();

            clientesCadastrados.Add(
                funcoesCliente.CadastrarCliente(nome, endereco, cpf)
            );

            Console.WriteLine("Cliente novo cadastrado!");

            break;
        case 2: 
            Console.WriteLine();
            break;
        case 3: 
            Console.WriteLine();
            break;
        case 4:
            Console.WriteLine("Lista de clientes cadastrados e seus pedidos: ");
            for(int i = 0; i < clientesCadastrados.Count(); i++)
            {
                Console.WriteLine(
                    "===" +
                    $"Nome: {clientesCadastrados[i].Nome}\n" +
                    $"Endereço: {clientesCadastrados[i].Endereco}\n" +
                    $"Endereço: {clientesCadastrados[i].Cpf}\n" +
                    "==="
                );
            }

            break;
        case 5:
            Console.WriteLine();
            break;
    }
}