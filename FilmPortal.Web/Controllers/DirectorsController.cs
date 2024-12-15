using FilmPortal.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Services;

namespace Project.Web.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly DirectorService _directorService;

        public DirectorsController(DirectorService directorService)
        {
            _directorService = directorService;
        }

        public async Task<IActionResult> Index()
        {
            var directors = await _directorService.GetAllDirectorsAsync();
            return View(directors);
        }

        public async Task<IActionResult> Details(int id)
        {
            var director = await _directorService.GetDirectorByIdAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Director director)
        {
            if (ModelState.IsValid)
            {
                await _directorService.AddDirectorAsync(director);
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var director = await _directorService.GetDirectorByIdAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Director director)
        {
            if (ModelState.IsValid)
            {
                await _directorService.UpdateDirectorAsync(director);
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var director = await _directorService.GetDirectorByIdAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            return View(director);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _directorService.DeleteDirectorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
