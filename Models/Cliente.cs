using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5.Classes
{
    public class Cliente
    {
        private int idCliente;
        private string nome;
        private string endereco;
        private string cpf;
        private List<Pedido> pedidosFeitos = new List<Pedido>();

        public Cliente()
        {
            
        }
        public Cliente(int idCliente, string nome, string endereco,  string cpf)
        {
            this.idCliente = idCliente;
            this.nome = nome;
            this.endereco = endereco;
            this.cpf = cpf;
        }

        public int Id
        {
            get { return this.idCliente;  }
        }
        public string Nome 
        { 
            get { return this.nome;  }
            set { this.nome = value;  }
        }
        public string Endereco
        {
            get { return this.endereco; }
            set { this.endereco = value; }
        }
        public string Cpf 
        {
            get { return this.cpf; }
            set { this.cpf = value; }
        }

        public List<Pedido> retornarPedidos
        {
            get { return this.pedidosFeitos; }
        }

        public void setarPedido(Pedido pedido)
        {
            this.pedidosFeitos.Add(pedido);
        }
    }
}