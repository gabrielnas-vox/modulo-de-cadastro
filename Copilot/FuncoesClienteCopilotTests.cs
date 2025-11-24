using System;
using Xunit;
using Fase5.Services;
using Fase5.Classes;

namespace Fase5.CopilotTests
{
    public class FuncoesClienteCopilotTests
    {
        private readonly FuncoesCliente _service = new FuncoesCliente();

        [Fact(DisplayName = "Deve cadastrar cliente válido")]
        public void CadastrarCliente_DadosValidos_RetornaCliente()
        {
            // Arrange
            string nome = "João da Silva";
            string endereco = "Rua A,123";
            string cpf = "123.456.789-10"; //14 chars com pontuação

            // Act
            var cliente = _service.CadastrarCliente(nome, endereco, cpf);

            // Assert
            Xunit.Assert.NotNull(cliente);
            Xunit.Assert.Equal(nome, cliente.Nome);
            Xunit.Assert.Equal(endereco, cliente.Endereco);
            Xunit.Assert.Equal(cpf, cliente.Cpf);
        }

        [Fact(DisplayName = "Deve retornar null quando nome é nulo")]
        public void CadastrarCliente_NomeNull_RetornaNull()
        {
            var cliente = _service.CadastrarCliente(null, "Rua B", "123.456.789-10");
            Xunit.Assert.Null(cliente);
        }

        [Fact(DisplayName = "Deve retornar null quando endereço é nulo")]
        public void CadastrarCliente_EnderecoNull_RetornaNull()
        {
            var cliente = _service.CadastrarCliente("Maria", null, "123.456.789-10");
            Xunit.Assert.Null(cliente);
        }

        [Fact(DisplayName = "Deve retornar null quando CPF é nulo")]
        public void CadastrarCliente_CpfNull_RetornaNull()
        {
            var cliente = _service.CadastrarCliente("Pedro", "Rua C", null);
            Xunit.Assert.Null(cliente);
        }

        [Fact(DisplayName = "Deve retornar null quando CPF inválido (tamanho diferente de14)")]
        public void CadastrarCliente_CpfInvalido_RetornaNull()
        {
            var cliente = _service.CadastrarCliente("Ana", "Rua D", "12345678910"); //11 chars sem pontuação
            Xunit.Assert.Null(cliente);
        }

        [Fact(DisplayName = "IDs devem incrementar a cada cadastro válido")]
        public void CadastrarCliente_IdsIncrementam()
        {
            var c1 = _service.CadastrarCliente("User1", "Rua1", "123.456.789-10");
            var c2 = _service.CadastrarCliente("User2", "Rua2", "987.654.321-00");

            Xunit.Assert.NotNull(c1);
            Xunit.Assert.NotNull(c2);
            Xunit.Assert.NotEqual(c1.Id, c2.Id);
            Xunit.Assert.Equal(c1.Id +1, c2.Id);
        }
    }
}
