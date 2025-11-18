using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5.Classes
{
    public class Pedido
    {
        private int idPedido;
        private DateOnly estimativaEntrega;
        private string formaPagamento;
        private string desconto;
        Cliente cliente;
        Produto produto;

        public Pedido(int id, Cliente cliente, Produto produto, DateOnly estimativa, string formaPagamento) 
        {
            this.cliente = cliente;
            this.produto = produto;
            this.estimativaEntrega = estimativa;
            this.formaPagamento = formaPagamento;
        }

        public DateOnly EstimativaEntrega { get; set; }
        public string FormaPagamento { get; set; }
        public string Cliente { get { return cliente.Nome; } }
    }
}