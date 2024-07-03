using Libreria.Context;
using Libreria.Modelos;
using Libreria.Repositorios.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Repositorios.implementaciones
{
    public class LibroRepository : ILibroRepository
    {
        private readonly LibreriaDbContext _context;

        public LibroRepository(LibreriaDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Libro>> GetAllAsync()
        {
            return await _context.Libros
                            .Include(l => l.Autor)
                            .Include(l => l.Genero)
                            .ToListAsync();
        }

        public async Task<Libro> GetByIdAsync(int id)
        {
            return await _context.Libros
                        .Include(l => l.Autor)
                        .Include(l => l.Genero)
                        .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task InsertAsync(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Libro libro)
        {
            var existingLibro = await _context.Libros.FindAsync(libro.Id);
            if (existingLibro == null)
            {
                throw new KeyNotFoundException("Libro no encontrado");
            }

            _context.Entry(existingLibro).CurrentValues.SetValues(libro);
            await _context.SaveChangesAsync();
        }
    }
}
