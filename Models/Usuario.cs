namespace Fase5.Classes
{
    public class Usuario
    {
        private int idUsuario;
        private string email;
        private string senha;
        public string username;

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
            return $"Id = {this.Id}, Email = {this.email}, Username = {this.username}";
        }
        public int Id { get; set; }
        public string Email { 
            get { return this.email; }
            set { email = value; }
        }
        public string Senha
        {
            get { return this.senha; }
            set { senha = value; }
        }
    }
}