using FilmPortal.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Services;

namespace Project.Web.Controllers
{
    public class MovieLikesController : Controller
    {
        private readonly MovieLikeService _movieLikeService;

        public MovieLikesController(MovieLikeService movieLikeService)
        {
            _movieLikeService = movieLikeService;
        }

        public async Task<IActionResult> Index()
        {
            var movieLikes = await _movieLikeService.GetAllAsync();
            return View(movieLikes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Like(int movieId, int userId)
        {
            var movieLike = new MovieLike
            {
                MovieId = movieId,
                UserId = userId
            };

            await _movieLikeService.AddAsync(movieLike);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Unlike(int movieId, int userId)
        {
            await _movieLikeService.DeleteAsync(movieId, userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
