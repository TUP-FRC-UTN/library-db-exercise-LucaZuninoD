using Libreria.Context;
using Libreria.Modelos;
using Libreria.Repositorios.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Repositorios.implementaciones
{
    public class AutorRepository : IAutorRepository
    {
        private readonly LibreriaDbContext _context;
        public AutorRepository(LibreriaDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Autor>> GetAllAsync()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<Autor> GetByIdAsync(int id)
        {
            return await _context.Autores.FindAsync(id);
        }

        public async Task InsertAsync(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Autor autor)
        {
            var existingAutor = await _context.Autores.FindAsync(autor.Id);
            if (existingAutor == null)
            {
                throw new KeyNotFoundException("Autor no encontrado");
            }

            _context.Entry(existingAutor).CurrentValues.SetValues(autor);
            await _context.SaveChangesAsync();
        }
    }
}
