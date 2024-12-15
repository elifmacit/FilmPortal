using Microsoft.AspNetCore.Mvc;

namespace FilmPortal.Web.Controllers
{
    public class AuthController : Controller
    {

        public async Task<IActionResult> Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            return View();

        }

    }
}



