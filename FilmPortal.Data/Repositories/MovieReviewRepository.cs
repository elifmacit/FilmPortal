using FilmPortal.Core.Entities;
using FilmPortal.Data.Context;
using Microsoft.EntityFrameworkCore;
using Project.Core.Interfaces;

namespace Project.Data.Repositories
{
    public class MovieReviewRepository : IMovieReviewRepository
    {
        private readonly FilmPortalDbContext _context;

        public MovieReviewRepository(FilmPortalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieReview>> GetAllAsync()
        {
            return await _context.MovieReviews
                .Include(mr => mr.Movie)
                .Include(mr => mr.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieReview>> GetByMovieIdAsync(int movieId)
        {
            return await _context.MovieReviews
                .Where(mr => mr.MovieId == movieId)
                .Include(mr => mr.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieReview>> GetByUserIdAsync(int userId)
        {
            return await _context.MovieReviews
                .Where(mr => mr.UserId == userId)
                .Include(mr => mr.Movie)
                .ToListAsync();
        }

        public async Task<MovieReview> GetByIdAsync(int id)
        {
            return await _context.MovieReviews
                .Include(mr => mr.Movie)
                .Include(mr => mr.User)
                .FirstOrDefaultAsync(mr => mr.Id == id);
        }

        public async Task AddAsync(MovieReview movieReview)
        {
            await _context.MovieReviews.AddAsync(movieReview);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MovieReview movieReview)
        {
            _context.MovieReviews.Update(movieReview);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movieReview = await GetByIdAsync(id);
            if (movieReview != null)
            {
                _context.MovieReviews.Remove(movieReview);
                await _context.SaveChangesAsync();
            }
        }
    }
}
