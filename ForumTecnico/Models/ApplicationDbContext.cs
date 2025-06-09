using Microsoft.EntityFrameworkCore;

namespace ForumTecnico.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tema> Temas { get; set; }
    }
}