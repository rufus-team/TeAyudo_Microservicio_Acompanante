﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AcompananteContext))]
    [Migration("20240226065911_test2")]
    partial class test2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Acompanante", b =>
                {
                    b.Property<int>("AcompananteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcompananteID"));

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("AcompananteID");

                    b.HasIndex("UsuarioID")
                        .IsUnique();

                    b.ToTable("Acompanante");
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

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioID"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EsAcompanante")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("FotoPerfil")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioID");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Acompanante", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithOne("Acompanante")
                        .HasForeignKey("Domain.Entities.Acompanante", "UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
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

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Acompanante")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}