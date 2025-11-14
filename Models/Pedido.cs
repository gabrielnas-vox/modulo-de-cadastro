using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5.Classes
{
    internal class Pedido
    {
        private int idPedido;
        private DateOnly estimativaEntrega;
        private string formaPagamento;
        Cliente cliente;
        Produto produto;
        public Pedido(Cliente cliente, Produto produto, int id, DateOnly estimativa, string formaPagamento) 
        {
            this.cliente = cliente;
            this.produto = produto;
            this.estimativaEntrega = estimativa;
            this.formaPagamento = formaPagamento;
        }

        public DateOnly EstimativaEntrega { get; set; }
        public string FormaPagamento { get; set; }
    }
}
