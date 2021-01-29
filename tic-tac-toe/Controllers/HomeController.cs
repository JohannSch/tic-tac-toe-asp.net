using Microsoft.AspNetCore.Mvc;

namespace tic_tac_toe.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => RedirectToAction("StartGame", "Game");
    }
}
