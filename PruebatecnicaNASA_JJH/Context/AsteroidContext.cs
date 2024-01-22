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
            modelBuilder.Entity<AsteroidEntity>()
                .ToTable("Asteroid");


            modelBuilder.Entity<AsteroidEntity>()
                .HasKey(a => a.Id); // Establecer la clave primaria

            modelBuilder.Entity<AsteroidEntity>()
                .Property(a => a.Name)
                .IsRequired(); // Hacer que el nombre sea obligatorio

            modelBuilder.Entity<AsteroidEntity>()
                .Property(a => a.EstimatedDiameter)
                .HasColumnName("Diameter")
                .IsRequired();

            modelBuilder.Entity<AsteroidEntity>()
                .Property(a => a.Velocity)
                .IsRequired();

            modelBuilder.Entity<AsteroidEntity>()
                .Property(a => a.Date)
                .IsRequired();

            modelBuilder.Entity<AsteroidEntity>()
                .Property(a => a.Planet)
                .IsRequired();
        }
    }
}
