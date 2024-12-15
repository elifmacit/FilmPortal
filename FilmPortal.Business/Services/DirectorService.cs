using FilmPortal.Core.Entities;
using Project.Core.Interfaces;

namespace Project.Business.Services
{
    public class DirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task<Director> GetDirectorByIdAsync(int id)
        {
            return await _directorRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Director>> GetAllDirectorsAsync()
        {
            return await _directorRepository.GetAllAsync();
        }

        public async Task AddDirectorAsync(Director director)
        {
            await _directorRepository.AddAsync(director);
        }

        public async Task UpdateDirectorAsync(Director director)
        {
            await _directorRepository.UpdateAsync(director);
        }

        public async Task DeleteDirectorAsync(int id)
        {
            await _directorRepository.DeleteAsync(id);
        }
    }
}
