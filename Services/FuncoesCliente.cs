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
            if(string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(endereco) || string.IsNullOrWhiteSpace(cpf))
            {
                Console.WriteLine("Por favor, preencha todas as informações de cadastro do cliente.");
                return null;
            }

            if(cpf.Count() != 14)
            {
                Console.WriteLine("CPF inválido. Por favor, informe o CPF com pontuação.");
                return null;
            }

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