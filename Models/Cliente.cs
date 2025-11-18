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

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }
    }
}