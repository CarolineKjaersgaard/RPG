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

        public IActionResult RoomScreen()
        {
            return View();
        }

        public IActionResult CombatScreen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Start()
        {
            var result = _api.StartGame();

            if (result is OkObjectResult okResult)
            {
                var data = okResult.Value as Dictionary<string, object>;

                if (data != null && data.TryGetValue("result", out var successObj) && (bool)successObj)
                {
                    var roomResult = _api.EnterRoom(0, 0);
                    Console.WriteLine(roomResult);
                    return RedirectToAction("RoomScreen");
                } else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Stop()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Continue()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Loot()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Attack()
        {
            return Json(new
            {
                log = "Enemy took 999 damage!"
            });
        }
        
        [HttpPost]
        public IActionResult Flee()
        {
            return RedirectToAction("RoomScreen");
        }

        [HttpPost]
        public IActionResult Explore()
        {
            return RedirectToAction("CombatScreen");
        }
    }
}
