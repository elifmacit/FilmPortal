using FilmPortal.Core.Entities;

namespace FilmPortal.Core.Interfaces
{
    public interface IMovieCategoryRepository
    {
        Task<IEnumerable<MovieCategory>> GetAllAsync();
        Task<IEnumerable<MovieCategory>> GetByMovieIdAsync(int movieId);
        Task<IEnumerable<MovieCategory>> GetByCategoryIdAsync(int categoryId);
        Task AddAsync(MovieCategory movieCategory);
        Task DeleteAsync(int movieId, int categoryId);
    }
}
