using Fase5.Classes;

namespace Fase5.Services
{
    public class FuncoesPedido
    {
        int idAtual = 0;

        public Pedido gerarPedido(Cliente cliente, Produto produto, DateOnly estimativa, string formaPagamento)
        {
            if(cliente == null || produto == null || formaPagamento == null)
            {
                Console.WriteLine("Por favor, preencha todos os campos para gerar o pedido.");
                return null;
            }

            if(estimativa <= DateOnly.FromDateTime(DateTime.Today))
            {
                Console.WriteLine("A data estimada de entrega é inválida. Por favor, selecione uma data futura.");
                return null;
            }

            Pedido novoPedido = new Pedido(
                idAtual++,
                cliente,
                produto,
                estimativa,
                formaPagamento
            );

            return novoPedido;
        }
    }
}