using FilmPortal.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Services;

namespace Project.Web.Controllers
{
    public class MovieReviewsController : Controller
    {
        private readonly MovieReviewService _movieReviewService;

        public MovieReviewsController(MovieReviewService movieReviewService)
        {
            _movieReviewService = movieReviewService;
        }

        public async Task<IActionResult> Index()
        {
            var movieReviews = await _movieReviewService.GetAllAsync();
            return View(movieReviews);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movieReview = await _movieReviewService.GetByIdAsync(id);
            if (movieReview == null)
            {
                return NotFound();
            }
            return View(movieReview);
        }

        [HttpGet]
        public IActionResult Create(int movieId)
        {
            var movieReview = new MovieReview { MovieId = movieId };
            return View(movieReview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieReview movieReview)
        {
            if (ModelState.IsValid)
            {
                await _movieReviewService.AddAsync(movieReview);
                return RedirectToAction(nameof(Index));
            }
            return View(movieReview);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movieReview = await _movieReviewService.GetByIdAsync(id);
            if (movieReview == null)
            {
                return NotFound();
            }
            return View(movieReview);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieReview movieReview)
        {
            if (ModelState.IsValid)
            {
                await _movieReviewService.UpdateAsync(movieReview);
                return RedirectToAction(nameof(Index));
            }
            return View(movieReview);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var movieReview = await _movieReviewService.GetByIdAsync(id);
            if (movieReview == null)
            {
                return NotFound();
            }
            return View(movieReview);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieReviewService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
