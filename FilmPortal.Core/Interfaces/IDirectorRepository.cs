using FilmPortal.Core.Entities;

namespace Project.Core.Interfaces
{
    public interface IDirectorRepository
    {
        Task<Director> GetByIdAsync(int id);
        Task<IEnumerable<Director>> GetAllAsync();
        Task AddAsync(Director director);
        Task UpdateAsync(Director director);
        Task DeleteAsync(int id);
    }
}
