using Libreria.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Context
{
    public class LibreriaDbContext : DbContext
    {
        public LibreriaDbContext(DbContextOptions<LibreriaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Insertar géneros
            modelBuilder.Entity<Genero>().HasData(
                new Genero { Id = 1, Nombre = "Ficción" },
                new Genero { Id = 2, Nombre = "No Ficción" },
                new Genero { Id = 3, Nombre = "Fantasía" }
            );

            // Insertar autores
            modelBuilder.Entity<Autor>().HasData(
                new Autor { Id = 1, Nombre = "Autor 1", FechaNacimiento = new DateTime(1970, 1, 1) },
                new Autor { Id = 2, Nombre = "Autor 2", FechaNacimiento = new DateTime(1980, 2, 2) }
            );

            // Insertar libros
            modelBuilder.Entity<Libro>().HasData(
                new Libro { Id = 1, ISBN = 1111111, Titulo = "Libro 1", AutorId = 1, GeneroId = 1, FechaPublicacion = new DateTime(2000, 1, 1) },
                new Libro { Id = 2, ISBN = 2222222, Titulo = "Libro 2", AutorId = 1, GeneroId = 2, FechaPublicacion = new DateTime(2001, 2, 2) },
                new Libro { Id = 3, ISBN = 3333333, Titulo = "Libro 3", AutorId = 1, GeneroId = 3, FechaPublicacion = new DateTime(2002, 3, 3) },
                new Libro { Id = 4, ISBN = 4444444, Titulo = "Libro 4", AutorId = 2, GeneroId = 1, FechaPublicacion = new DateTime(2003, 4, 4) },
                new Libro { Id = 5, ISBN = 5555555, Titulo = "Libro 5", AutorId = 2, GeneroId = 2, FechaPublicacion = new DateTime(2004, 5, 5) },
                new Libro { Id = 6, ISBN = 6666666, Titulo = "Libro 6", AutorId = 2, GeneroId = 3, FechaPublicacion = new DateTime(2005, 6, 6) }
            );
        }
    }
}
