using Microsoft.EntityFrameworkCore;
using TesteFCamara.Domain.Entities;

namespace TesteFCamara.Persistence.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; } 

    }
}
