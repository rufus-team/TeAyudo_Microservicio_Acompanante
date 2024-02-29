using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AcompananteContext : DbContext
    {
        public AcompananteContext(DbContextOptions<AcompananteContext> options) : base(options)
        {
        }


        public DbSet<Acompanante> Acompanante { get; set; }
        public DbSet<Horarios> Horarios { get; set; }
        public DbSet<Tag> Tag { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //ejecuta el metodo de la superclase para las convenciones y configs de EF

            //Defino las PK
            modelBuilder.Entity<Acompanante>().HasKey(s => s.AcompananteID);
            modelBuilder.Entity<Horarios>().HasKey(s => s.AcompananteID);
            modelBuilder.Entity<Tag>().HasKey(s => s.TagID);

            //Defino relaciones
            modelBuilder.Entity<Horarios>()
                .HasOne<Acompanante>(s => s.Acompanante)
                .WithOne(m => m.Horarios)
                .HasForeignKey<Horarios>(d => d.AcompananteID); //defino que la pk de horarios tambien es fk


            modelBuilder.Entity<Acompanante>()
                .HasMany(s => s.Tags)
                .WithMany(m => m.Acompanantes)
                .UsingEntity(
                    "AcompananteTag",
                    l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagID"),
                    r => r.HasOne(typeof(Acompanante)).WithMany().HasForeignKey("AcompananteID")
                );


            //Defino que la pk de horarios no es autoincremental
            modelBuilder.Entity<Horarios>()
                    .Property(s => s.AcompananteID)
                    .ValueGeneratedNever();

            //Defino los nombres de las tablas 
            modelBuilder.Entity<Acompanante>().ToTable("Acompañante");
            modelBuilder.Entity<Horarios>().ToTable("Horarios");
            modelBuilder.Entity<Tag>().ToTable("Tag");

            //Precargo la tabla de tags
            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    TagID = 1,
                    Nombre = "Actitud positiva",
                },
                new Tag
                {
                    TagID = 2,
                    Nombre = "Compromiso",
                },
                new Tag
                {
                    TagID = 3,
                    Nombre = "Habilidades de comunicación",
                },
                new Tag
                {
                    TagID = 4,
                    Nombre = "Adaptabilidad",
                },
                new Tag
                {
                    TagID = 5,
                    Nombre = "Responsabilidad",
                },
                new Tag
                {
                    TagID = 6,
                    Nombre = "Iniciativa",
                },
                new Tag
                {
                    TagID = 7,
                    Nombre = "Ética laboral",
                },
                new Tag
                {
                    TagID = 8,
                    Nombre = "Honestidad",
                },
                new Tag
                {
                    TagID = 9,
                    Nombre = "Organización",
                },
                new Tag
                {
                    TagID = 10,
                    Nombre = "Aprendizaje continuo",
                },
                new Tag
                {
                    TagID = 11,
                    Nombre = "Paciencia",
                },
                new Tag
                {
                    TagID = 12,
                    Nombre = "Cariño",
                }
            );


        }
    }
}
