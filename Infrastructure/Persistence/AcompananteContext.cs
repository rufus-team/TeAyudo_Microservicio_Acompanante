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
    
            modelBuilder.Entity<Horarios>()
                .HasOne<Acompanante>(s => s.Acompanante)
                .WithOne(m => m.Horarios)
                .HasForeignKey<Horarios>(d => d.AcompananteID);

            //Defino que la pk de horarios no es autoincremental
            modelBuilder.Entity<Horarios>()
                .Property(s => s.AcompananteID)
                .ValueGeneratedNever();

            //Defino los nombres de las tablas 
            modelBuilder.Entity<Acompanante>().ToTable("Acompañante");
            modelBuilder.Entity<Horarios>().ToTable("Horarios");
        }




    }
}
