﻿// <auto-generated />
using System;
using Libreria.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Libreria.Migrations
{
    [DbContext(typeof(LibreriaDbContext))]
    [Migration("20240703193151_InitialCreate2")]
    partial class InitialCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Libreria.Modelos.Autor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Autores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaNacimiento = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Autor 1"
                        },
                        new
                        {
                            Id = 2,
                            FechaNacimiento = new DateTime(1980, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Autor 2"
                        });
                });

            modelBuilder.Entity("Libreria.Modelos.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Ficción"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "No Ficción"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Fantasía"
                        });
                });

            modelBuilder.Entity("Libreria.Modelos.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPublicacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<int>("ISBN")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Libros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AutorId = 1,
                            FechaPublicacion = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GeneroId = 1,
                            ISBN = 1111111,
                            Titulo = "Libro 1"
                        },
                        new
                        {
                            Id = 2,
                            AutorId = 1,
                            FechaPublicacion = new DateTime(2001, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GeneroId = 2,
                            ISBN = 2222222,
                            Titulo = "Libro 2"
                        },
                        new
                        {
                            Id = 3,
                            AutorId = 1,
                            FechaPublicacion = new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GeneroId = 3,
                            ISBN = 3333333,
                            Titulo = "Libro 3"
                        },
                        new
                        {
                            Id = 4,
                            AutorId = 2,
                            FechaPublicacion = new DateTime(2003, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GeneroId = 1,
                            ISBN = 4444444,
                            Titulo = "Libro 4"
                        },
                        new
                        {
                            Id = 5,
                            AutorId = 2,
                            FechaPublicacion = new DateTime(2004, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GeneroId = 2,
                            ISBN = 5555555,
                            Titulo = "Libro 5"
                        },
                        new
                        {
                            Id = 6,
                            AutorId = 2,
                            FechaPublicacion = new DateTime(2005, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GeneroId = 3,
                            ISBN = 6666666,
                            Titulo = "Libro 6"
                        });
                });

            modelBuilder.Entity("Libreria.Modelos.Libro", b =>
                {
                    b.HasOne("Libreria.Modelos.Autor", "Autor")
                        .WithMany("Libros")
                        .HasForeignKey("AutorId");

                    b.HasOne("Libreria.Modelos.Genero", "Genero")
                        .WithMany("Libros")
                        .HasForeignKey("GeneroId");

                    b.Navigation("Autor");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("Libreria.Modelos.Autor", b =>
                {
                    b.Navigation("Libros");
                });

            modelBuilder.Entity("Libreria.Modelos.Genero", b =>
                {
                    b.Navigation("Libros");
                });
#pragma warning restore 612, 618
        }
    }
}