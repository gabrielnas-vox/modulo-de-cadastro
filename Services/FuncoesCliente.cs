using Fase5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5.Services
{
    public class FuncoesCliente
    {
        private int idAtual = 0;

        public Cliente CadastrarCliente(string nome, string endereco, string cpf)
        {
            Cliente novoCliente = new Cliente(
                idAtual++,
                nome,
                endereco,
                cpf
            );

            return novoCliente;
        }
    }
}