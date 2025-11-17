using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5.Records
{
    public record Login
    {
        public int idAtual { get; init; }
        public string email { get; init; }
        public string senha { get; init; }
        public string username { get; init; }

        public Login(string email, string senha)
        {
            this.email = email;
            this.senha = senha;
        }
        public Login(string username)
        {
            this.username = username;
        }

        public Login(int id, string username)
        {
            this.idAtual = id;
            this.username = username;
        }

        public Login(int id, string email, string senha)
        {
            this.idAtual = id;
            this.email = email;
            this.senha = senha;
        }

        public Login(int id, string email, string senha, string username)
        {
            this.idAtual = id;
            this.email = email;
            this.senha = senha;
            this.username = username;
        }
    }
}