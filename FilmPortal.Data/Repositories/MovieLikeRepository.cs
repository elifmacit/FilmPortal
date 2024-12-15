using FilmPortal.Core.Entities;
using FilmPortal.Data.Context;
using Microsoft.EntityFrameworkCore;
using Project.Core.Interfaces;

namespace Project.Data.Repositories
{
    public class MovieLikeRepository : IMovieLikeRepository
    {
        private readonly FilmPortalDbContext _context;

        public MovieLikeRepository(FilmPortalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieLike>> GetAllAsync()
        {
            return await _context.MovieLikes
                .Include(ml => ml.Movie)
                .Include(ml => ml.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieLike>> GetByMovieIdAsync(int movieId)
        {
            return await _context.MovieLikes
                .Where(ml => ml.MovieId == movieId)
                .Include(ml => ml.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<MovieLike>> GetByUserIdAsync(int userId)
        {
            return await _context.MovieLikes
                .Where(ml => ml.UserId == userId)
                .Include(ml => ml.Movie)
                .ToListAsync();
        }

        public async Task<MovieLike> GetByMovieAndUserIdAsync(int movieId, int userId)
        {
            return await _context.MovieLikes
                .FirstOrDefaultAsync(ml => ml.MovieId == movieId && ml.UserId == userId);
        }

        public async Task AddAsync(MovieLike movieLike)
        {
            await _context.MovieLikes.AddAsync(movieLike);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int movieId, int userId)
        {
            var movieLike = await GetByMovieAndUserIdAsync(movieId, userId);
            if (movieLike != null)
            {
                _context.MovieLikes.Remove(movieLike);
                await _context.SaveChangesAsync();
            }
        }
    }
}
