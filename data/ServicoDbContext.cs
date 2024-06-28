using Microsoft.EntityFrameworkCore;

namespace Servico.Data // Namespace corrected to match typical convention
{
    public class ServicoDbContext : DbContext
    {
        public ServicoDbContext(DbContextOptions<ServicoDbContext> options) : base(options)
        {
        }

        public DbSet<Trabalho> Trabalhos { get; set; } // DbSet for Trabalho entity

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trabalho>().HasKey(t => t.Id); // Configure primary key
        }
    }
}



