using Libreria.Modelos;

namespace Libreria.Repositorios.interfaces
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAllAsync();
        Task<Autor> GetByIdAsync(int id);
        Task InsertAsync(Autor autor);
        Task UpdateAsync(Autor autor);
        Task DeleteAsync(int id);
    }
}
