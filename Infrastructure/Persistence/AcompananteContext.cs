using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AcompananteContext : DbContext
    {
        public AcompananteContext(DbContextOptions<AcompananteContext> options) : base(options)
        {
        }


        public DbSet<Acompanante> Acompanante { get; set; }
        public DbSet<Horarios> Horarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //ejecuta el metodo de la superclase para las convenciones y configs de EF

            //Defino las PK
            modelBuilder.Entity<Acompanante>().HasKey(s => s.AcompananteID);
            modelBuilder.Entity<Horarios>().HasKey(s => s.AcompananteID);

            //Defino las FK
            modelBuilder.Entity<Acompanante>()
                .HasOne<Usuario>(s => s.Usuario)
                .WithOne(m => m.Acompanante)
                .HasForeignKey<Acompanante>(d => d.UsuarioID);

            modelBuilder.Entity<Horarios>()
                .HasOne<Acompanante>(s => s.Acompanante)
                .WithOne(m => m.Horarios)
                .HasForeignKey<Horarios>(d => d.AcompananteID);
        }




    }
}
