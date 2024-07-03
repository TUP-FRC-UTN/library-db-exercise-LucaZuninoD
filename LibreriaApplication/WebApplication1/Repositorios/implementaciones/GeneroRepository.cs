using Libreria.Context;
using Libreria.Modelos;
using Libreria.Repositorios.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Repositorios.implementaciones
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly LibreriaDbContext _context;
        public GeneroRepository(LibreriaDbContext context) 
        { 
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero != null)
            {
                _context.Generos.Remove(genero);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Genero>> GetAllAsync()
        {
            return await _context.Generos.ToListAsync();
        }

        public async Task<Genero> GetByIdAsync(int id)
        {
            return await _context.Generos.FindAsync(id);
        }

        public Task InsertAsync(Genero genero)
        { 
            _context.Generos.Add(genero);
            return _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genero genero)
        {
            var existingGenero = await _context.Generos.FindAsync(genero.Id);
            if (existingGenero == null)
            {
                throw new KeyNotFoundException("Género no encontrado");
            }

            _context.Entry(existingGenero).CurrentValues.SetValues(genero);
            await _context.SaveChangesAsync();
        }
    }
}
