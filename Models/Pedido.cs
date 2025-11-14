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
        public Pedido(Cliente cliente, int id, DateOnly estimativa, string formaPagamento) { }

        public DateOnly EstimativaEntrega { get; set; }
        public string FormaPagamento { get; set; }
    }
}
