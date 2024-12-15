using FilmPortal.Core.Entities;
using Project.Core.Interfaces;

namespace Project.Business.Services
{
    public class MovieLikeService
    {
        private readonly IMovieLikeRepository _movieLikeRepository;

        public MovieLikeService(IMovieLikeRepository movieLikeRepository)
        {
            _movieLikeRepository = movieLikeRepository;
        }

        public async Task<IEnumerable<MovieLike>> GetAllAsync()
        {
            return await _movieLikeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<MovieLike>> GetByMovieIdAsync(int movieId)
        {
            return await _movieLikeRepository.GetByMovieIdAsync(movieId);
        }

        public async Task<IEnumerable<MovieLike>> GetByUserIdAsync(int userId)
        {
            return await _movieLikeRepository.GetByUserIdAsync(userId);
        }

        public async Task<MovieLike> GetByMovieAndUserIdAsync(int movieId, int userId)
        {
            return await _movieLikeRepository.GetByMovieAndUserIdAsync(movieId, userId);
        }

        public async Task AddAsync(MovieLike movieLike)
        {
            // İş kuralları (ör. Duplicate kontrolü)
            var existingLike = await _movieLikeRepository.GetByMovieAndUserIdAsync(movieLike.MovieId, movieLike.UserId);
            if (existingLike == null)
            {
                await _movieLikeRepository.AddAsync(movieLike);
            }
        }

        public async Task DeleteAsync(int movieId, int userId)
        {
            // Silme işlemi öncesi iş kuralları
            await _movieLikeRepository.DeleteAsync(movieId, userId);
        }
    }
}
