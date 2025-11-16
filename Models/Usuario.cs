using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5.Classes
{
    internal class Usuario
    {
        private int idUsuario;
        private string email;
        private string senha;
        private string username;

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string email, string senha, string username)
        {
            this.idUsuario = idUsuario;
            this.email = email;
            this.senha = senha;
            this.username = username;
        }

        public string Email { get { return email; } }
        public string Senha { get { return senha; } }
        public string Username { get { return username; } }
    }
}