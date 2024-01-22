using Microsoft.EntityFrameworkCore;
using PruebatecnicaNASA_JJH.Entities;

namespace PruebatecnicaNASA_JJH.Context
{
    public class AsteroidContext : DbContext
    {
        public AsteroidContext(DbContextOptions<AsteroidContext> options)
            : base(options)
        {

        }

        public DbSet<AsteroidEntity> AsteroidEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
