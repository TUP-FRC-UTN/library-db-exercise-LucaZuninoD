using Libreria.Modelos;

namespace Libreria.Repositorios.interfaces
{
    public interface ILibroRepository
    {
        Task<IEnumerable<Libro>> GetAllAsync();
        Task<Libro> GetByIdAsync(int id);
        Task InsertAsync(Libro libro);
        Task UpdateAsync(Libro libro);
        Task DeleteAsync(int id);
    }
}
