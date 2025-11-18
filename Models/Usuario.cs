using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fase5.Classes
{
    public class Usuario
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

        public override string ToString()
        {
            return $"Id = {this.Id}, Email = {this.email}, Username = {this.Username}";
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Username { get; set; }
    }
}