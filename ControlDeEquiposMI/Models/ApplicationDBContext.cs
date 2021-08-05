using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ControlDeEquiposMI.Models
{
    public partial class ApplicationDBContext : DbContext
    {
        public DbSet<Jugador> Jugador { get; set; }
        public DbSet<EstadoJugador> EstadoJugador { get; set; }
        public DbSet<Equipo> Equipo { get; set; }
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local)\\sqlexpress2016;Database=dbequipomi;User Id=sa;Password=sql2016");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EstadoJugador>().HasData(
                new EstadoJugador { Id = 1, Nombre = "Activo", FechaCreacion = DateTime.Now.ToLocalTime() },
                new EstadoJugador { Id = 2, Nombre = "Cancelado", FechaCreacion = DateTime.Now.ToLocalTime() },
                new EstadoJugador { Id = 3, Nombre = "AgenteLibre", FechaCreacion = DateTime.Now.ToLocalTime() }
            );
            modelBuilder.Entity<Jugador>().HasKey(b=>b.Id);
            modelBuilder.Entity<Jugador>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Jugador>().Property(b => b.Nombre).IsRequired();

            modelBuilder.Entity<Equipo>().HasKey(b => b.Id);
            modelBuilder.Entity<Equipo>().Property(b => b.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Equipo>().Property(b => b.Nombre).IsRequired();

           
         
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
