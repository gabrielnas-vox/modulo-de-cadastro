using Fase5.Classes;
using Fase5.Services;

FuncoesCliente funcoesCliente = new FuncoesCliente();

Cliente novoCliente = funcoesCliente.CadastrarCliente("Thiago", "Rua teste, 123", "312");

Console.WriteLine(novoCliente.Endereco);