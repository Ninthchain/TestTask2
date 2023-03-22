using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public GameContext(DbContextOptions options) : base(options)
        {

        }
        public GameContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=gamedb;Trusted_Connection=true;TrustServerCertificate=true");
        }

    }
}
