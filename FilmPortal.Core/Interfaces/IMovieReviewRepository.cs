using FilmPortal.Core.Entities;

namespace Project.Core.Interfaces
{
    public interface IMovieReviewRepository
    {
        Task<IEnumerable<MovieReview>> GetAllAsync();
        Task<IEnumerable<MovieReview>> GetByMovieIdAsync(int movieId);
        Task<IEnumerable<MovieReview>> GetByUserIdAsync(int userId);
        Task<MovieReview> GetByIdAsync(int id);
        Task AddAsync(MovieReview movieReview);
        Task UpdateAsync(MovieReview movieReview);
        Task DeleteAsync(int id);
    }
}
