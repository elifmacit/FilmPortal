using FilmPortal.Core.Entities;
using Project.Core.Interfaces;

namespace Project.Business.Services
{
    public class MovieReviewService
    {
        private readonly IMovieReviewRepository _movieReviewRepository;

        public MovieReviewService(IMovieReviewRepository movieReviewRepository)
        {
            _movieReviewRepository = movieReviewRepository;
        }

        public async Task<IEnumerable<MovieReview>> GetAllAsync()
        {
            return await _movieReviewRepository.GetAllAsync();
        }

        public async Task<IEnumerable<MovieReview>> GetByMovieIdAsync(int movieId)
        {
            return await _movieReviewRepository.GetByMovieIdAsync(movieId);
        }

        public async Task<IEnumerable<MovieReview>> GetByUserIdAsync(int userId)
        {
            return await _movieReviewRepository.GetByUserIdAsync(userId);
        }

        public async Task<MovieReview> GetByIdAsync(int id)
        {
            return await _movieReviewRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(MovieReview movieReview)
        {
            // İş kuralları uygulanabilir (ör. duplicate kontrolü)
            await _movieReviewRepository.AddAsync(movieReview);
        }

        public async Task UpdateAsync(MovieReview movieReview)
        {
            // Güncelleme öncesi validasyon
            await _movieReviewRepository.UpdateAsync(movieReview);
        }

        public async Task DeleteAsync(int id)
        {
            // Silme işlemi öncesi iş kuralları uygulanabilir
            await _movieReviewRepository.DeleteAsync(id);
        }
    }
}
