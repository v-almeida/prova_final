namespace Servico.Data
{
    public class Trabalho
    {
        public Trabalho()
        {
            Nome = ""; // Initialize with a default value
        }

        public int Id { get; set; }
        public string Nome { get; set; } // Consider making this nullable (string?)
        public double Preco { get; set; }
        public bool Status { get; set; }
    }
}




