using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class GameController : Controller
    {
        public IActionResult IntroScreen()
        {
            return View();
        }
    }
}
