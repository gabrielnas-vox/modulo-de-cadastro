using Fase5.Classes;
using Fase5.Services;

FuncoesCliente funcoesCliente = new FuncoesCliente();
FuncoesProduto funcoesProduto = new FuncoesProduto();
FuncoesPedido funcoesPedido = new FuncoesPedido();
FuncoesMenu menu = new FuncoesMenu();

List<Cliente> clientesCadastrados = new List<Cliente>();
List<Produto> produtosCadastrados = new List<Produto>();
List<Pedido> pedidosCadastrados = new List<Pedido>();

int opcao;

string nome; // esse nome serve para todas as entidades

// Variáveis para cadastro do CLIENTE
string endereco;
string cpf;

// Variáveis para cadastro do PRODUTO
int quantidadeEstoque;
string categoria;
string descricao;

//Variáveis para cadastro do PEDIDO
int clienteQueComprou;
int produtoComprado;
DateOnly estimativaEntrega;
string formaPagamento;

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

            break;
        case 3:
            Console.WriteLine("-- Gerar pedido de compra --");

            menu.listarClientes(clientesCadastrados);

            Console.Write("Selecione o ID do cliente: ");
            clienteQueComprou = int.Parse(Console.ReadLine());

            Console.Write("Selecione o ID do produto: ");
            produtoComprado = int.Parse(Console.ReadLine());

            Console.Write("Qual será a estimativa de entrega (Ano/Mês/dias): ");
            estimativaEntrega = DateOnly.Parse(Console.ReadLine());

            Console.Write("Qual será a forma de pagamento: ");
            formaPagamento = Console.ReadLine();

            pedidosCadastrados.Add(funcoesPedido.gerarPedido(
                clientesCadastrados[clienteQueComprou],
                produtosCadastrados[produtoComprado],
                estimativaEntrega,
                formaPagamento
            ));

            break;
        case 4:
            menu.listarClientes(clientesCadastrados);
            break;
        case 5:
            menu.listarProdutos(produtosCadastrados);
            break;
    }
}