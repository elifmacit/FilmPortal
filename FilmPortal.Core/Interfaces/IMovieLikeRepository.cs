using FilmPortal.Core.Entities;

namespace Project.Core.Interfaces
{
    public interface IMovieLikeRepository
    {
        Task<IEnumerable<MovieLike>> GetAllAsync();
        Task<IEnumerable<MovieLike>> GetByMovieIdAsync(int movieId);
        Task<IEnumerable<MovieLike>> GetByUserIdAsync(int userId);
        Task<MovieLike> GetByMovieAndUserIdAsync(int movieId, int userId);
        Task AddAsync(MovieLike movieLike);
        Task DeleteAsync(int movieId, int userId);
    }
}
