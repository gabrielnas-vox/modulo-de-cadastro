using Fase5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Fase5.Services
{
    internal class FuncoesPedido
    {
        int idAtual = 0;

        public Pedido gerarPedido(Cliente cliente, Produto produto, DateOnly estimativa, string formaPagamento)
        {
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