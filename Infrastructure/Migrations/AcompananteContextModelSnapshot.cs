﻿// <auto-generated />
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AcompananteContext))]
    partial class AcompananteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AcompananteTag", b =>
                {
                    b.Property<int>("AcompananteID")
                        .HasColumnType("int");

                    b.Property<int>("TagID")
                        .HasColumnType("int");

                    b.HasKey("AcompananteID", "TagID");

                    b.HasIndex("TagID");

                    b.ToTable("AcompananteTag");
                });

            modelBuilder.Entity("Domain.Entities.Acompanante", b =>
                {
                    b.Property<int>("AcompananteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcompananteID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("AcompananteID");

                    b.ToTable("Acompañante", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Horarios", b =>
                {
                    b.Property<int>("AcompananteID")
                        .HasColumnType("int");

                    b.Property<int>("Domingo")
                        .HasColumnType("int");

                    b.Property<int>("Jueves")
                        .HasColumnType("int");

                    b.Property<int>("Lunes")
                        .HasColumnType("int");

                    b.Property<int>("Martes")
                        .HasColumnType("int");

                    b.Property<int>("Miercoles")
                        .HasColumnType("int");

                    b.Property<int>("Sabado")
                        .HasColumnType("int");

                    b.Property<int>("Viernes")
                        .HasColumnType("int");

                    b.HasKey("AcompananteID");

                    b.ToTable("Horarios", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Tag", b =>
                {
                    b.Property<int>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagID"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagID");

                    b.ToTable("Tag", (string)null);

                    b.HasData(
                        new
                        {
                            TagID = 1,
                            Nombre = "Actitud positiva"
                        },
                        new
                        {
                            TagID = 2,
                            Nombre = "Compromiso"
                        },
                        new
                        {
                            TagID = 3,
                            Nombre = "Habilidades de comunicación"
                        },
                        new
                        {
                            TagID = 4,
                            Nombre = "Adaptabilidad"
                        },
                        new
                        {
                            TagID = 5,
                            Nombre = "Responsabilidad"
                        },
                        new
                        {
                            TagID = 6,
                            Nombre = "Iniciativa"
                        },
                        new
                        {
                            TagID = 7,
                            Nombre = "Ética laboral"
                        },
                        new
                        {
                            TagID = 8,
                            Nombre = "Honestidad"
                        },
                        new
                        {
                            TagID = 9,
                            Nombre = "Organización"
                        },
                        new
                        {
                            TagID = 10,
                            Nombre = "Aprendizaje continuo"
                        },
                        new
                        {
                            TagID = 11,
                            Nombre = "Paciencia"
                        },
                        new
                        {
                            TagID = 12,
                            Nombre = "Cariño"
                        });
                });

            modelBuilder.Entity("AcompananteTag", b =>
                {
                    b.HasOne("Domain.Entities.Acompanante", null)
                        .WithMany()
                        .HasForeignKey("AcompananteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Horarios", b =>
                {
                    b.HasOne("Domain.Entities.Acompanante", "Acompanante")
                        .WithOne("Horarios")
                        .HasForeignKey("Domain.Entities.Horarios", "AcompananteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Acompanante");
                });

            modelBuilder.Entity("Domain.Entities.Acompanante", b =>
                {
                    b.Navigation("Horarios")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
