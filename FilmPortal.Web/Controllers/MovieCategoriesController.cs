using FilmPortal.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Services;

namespace Project.Web.Controllers
{
    public class MovieCategoriesController : Controller
    {
        private readonly MovieCategoryService _movieCategoryService;

        public MovieCategoriesController(MovieCategoryService movieCategoryService)
        {
            _movieCategoryService = movieCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var movieCategories = await _movieCategoryService.GetAllAsync();
            return View(movieCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieCategory movieCategory)
        {
            if (ModelState.IsValid)
            {
                await _movieCategoryService.AddAsync(movieCategory);
                return RedirectToAction(nameof(Index));
            }
            return View(movieCategory);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int movieId, int categoryId)
        {
            await _movieCategoryService.DeleteAsync(movieId, categoryId);
            return RedirectToAction(nameof(Index));
        }
    }
}
