using FilmPortal.Core.Entities;
using FilmPortal.Core.Interfaces;

namespace Project.Business.Services
{
    public class MovieCategoryService
    {
        private readonly IMovieCategoryRepository _movieCategoryRepository;

        public MovieCategoryService(IMovieCategoryRepository movieCategoryRepository)
        {
            _movieCategoryRepository = movieCategoryRepository;
        }

        public async Task<IEnumerable<MovieCategory>> GetAllAsync()
        {
            return await _movieCategoryRepository.GetAllAsync();
        }

        public async Task<IEnumerable<MovieCategory>> GetByMovieIdAsync(int movieId)
        {
            return await _movieCategoryRepository.GetByMovieIdAsync(movieId);
        }

        public async Task<IEnumerable<MovieCategory>> GetByCategoryIdAsync(int categoryId)
        {
            return await _movieCategoryRepository.GetByCategoryIdAsync(categoryId);
        }

        public async Task AddAsync(MovieCategory movieCategory)
        {
            // İş kuralları uygulanabilir (ör. duplicate kontrolü)
            await _movieCategoryRepository.AddAsync(movieCategory);
        }

        public async Task DeleteAsync(int movieId, int categoryId)
        {
            // İş kuralları uygulanabilir
            await _movieCategoryRepository.DeleteAsync(movieId, categoryId);
        }
    }
}
