using FilmPortal.Business.Services;
using FilmPortal.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Project.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly IMovieRepository _movieRepository;

        public MoviesController(CategoryService categoryService, IMovieRepository movieRepository)
        {
            _categoryService = categoryService;
            _movieRepository = movieRepository;
        }

        // Film Listesi
        public async Task<IActionResult> Index()
        {
            ViewBag.movies = await _movieRepository.GetAllAsync();  
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        //// Film Detayları
        //public async Task<IActionResult> Details(int id)
        //{
        //    var movie = await _movieService.GetMovieByIdAsync(id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(movie);
        //}

        //// Yeni Film Ekleme Formu
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// Yeni Film Ekleme İşlemi
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Movie movie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _movieService.AddMovieAsync(movie);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(movie);
        //}

        //// Film Güncelleme Formu
        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var movie = await _movieService.GetMovieByIdAsync(id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(movie);
        //}

        //// Film Güncelleme İşlemi
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Movie movie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _movieService.UpdateMovieAsync(movie);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(movie);
        //}

        //// Film Silme Onayı
        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var movie = await _movieService.GetMovieByIdAsync(id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(movie);
        //}

        //// Film Silme İşlemi
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _movieService.DeleteMovieAsync(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
