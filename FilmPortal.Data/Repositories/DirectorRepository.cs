using FilmPortal.Core.Entities;
using FilmPortal.Data.Context;
using Microsoft.EntityFrameworkCore;
using Project.Core.Interfaces;

namespace Project.Data.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly FilmPortalDbContext _context;

        public DirectorRepository(FilmPortalDbContext context)
        {
            _context = context;
        }

        public async Task<Director> GetByIdAsync(int id)
        {
            return await _context.Directors.FindAsync(id);
        }

        public async Task<IEnumerable<Director>> GetAllAsync()
        {
            return await _context.Directors.ToListAsync();
        }

        public async Task AddAsync(Director director)
        {
            await _context.Directors.AddAsync(director);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Director director)
        {
            _context.Directors.Update(director);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director != null)
            {
                _context.Directors.Remove(director);
                await _context.SaveChangesAsync();
            }
        }
    }
}
