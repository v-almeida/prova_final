namespace Servico.Data
{
    public class Usuario // Renamed to avoid conflict with namespace
    {
        public Usuario()
        {
            Email = ""; // Initialize with a default value
            Senha = ""; // Initialize with a default value
        }

        public int Id { get; set; } // Consider adding an Id property if necessary
        public string Email { get; set; } // Consider making this nullable (string?)
        public string Senha { get; set; } // Consider making this nullable (string?)
    }
}



