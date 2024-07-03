using Libreria.Modelos;

namespace Libreria.Repositorios.interfaces
{
    public interface IGeneroRepository
    {
        Task<IEnumerable<Genero>> GetAllAsync();
        Task<Genero> GetByIdAsync(int id);
        Task InsertAsync(Genero genero);
        Task UpdateAsync(Genero genero);
        Task DeleteAsync(int id);
    }
}
