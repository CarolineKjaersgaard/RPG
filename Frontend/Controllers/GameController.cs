using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameAPI _api;

        public GameController(IGameAPI api)
        {
            _api = api;
        }

        public IActionResult IntroScreen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Start()
        {
            var result = _api.StartGame();
            return result;
        }
    }
}
