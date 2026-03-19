using Microsoft.EntityFrameworkCore;
using AbonadosMunicipio.Enitities;

namespace AbonadosMunicipio.Infraestructura.DataBase
{
    public class AbonadosDbContext : DbContext
    {
        public AbonadosDbContext(DbContextOptions options) : base(options)
        {
        }
        //Tablas

        public DbSet<Abonados> _Abonados => Set<Abonados>();
        public DbSet<TiposServicio> _TiposServicio => Set<TiposServicio>();

        //Mapeos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Mapeo de la tabla Abonados
            modelBuilder.Entity<Abonados>(entity =>
            {
                entity.ToTable("Abonados");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("INT");

                entity.Property(e => e.NombreCompleto)
                .HasColumnName("NombreCompleto")
                .HasColumnType("VARCHAR(100)");

                entity.Property(e => e.Direccion)
                .HasColumnName("Direccion")
                .HasColumnType("VARCHAR(200)");

                entity.Property(e => e.NumeroMedidor)
                .HasColumnName("NumeroMedidor")
                .HasColumnType("VARCHAR(50)");

                entity.Property(e => e.ConsumoMensual)
                .HasColumnName("ConsumoMensual")
                .HasColumnType("INT");

                 entity.Property(e => e.TipoServicioId)
                .HasColumnName("TipoServicioId")
                .HasColumnType("INT");


            });
            //Mapeo de la tabla TiposServicio
            modelBuilder.Entity<TiposServicio>(entity =>
            {
                entity.ToTable("TiposServicio");
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("INT");

                entity.Property(e => e.Nombre)
                .HasColumnName("Nombre")
                .HasColumnType("VARCHAR(100)");
            });

        }
    }
}
