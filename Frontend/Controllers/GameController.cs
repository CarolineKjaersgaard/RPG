using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameAPI _api;
        private Room RoomOne;
        private Room RoomTwo;
        private Enemy EnemyOne;
        private Room CurrentRoom;

        public GameController(IGameAPI api)
        {
            _api = api;

            RoomOne = new Room()
            {
                Name = "Waste Reclamation",
                FlavorText = "A repugnant smell hits you the moment you step inside, followed by a sharp yellow glare that stabs at your eyes. You stand on a walkway of black metal - like everything else in this place, the material is one you don't recognize.<br /><br />Below, colossal tanks churn with rancid yellow liquid. Their surfaces bubble and seethe angrily. The steam rising from the tanks burns your nose and makes your eyes water.<br /><br />Refuse of various kinds drops randomly into the tanks. There are no pipes, chutes or other means of transportation, the waste seems to ooze out of the reflective ceiling, dropping heavily into the slurry.<br /><br />The sickly glow from the liquid casts long, shuddering shadows across the walls. Yet the light never seems to reach far. Despite the many sources, the room remains drowned in darkness.<br /><br />Ahead, you can vaguely spot the walkway splitting off into a maze of platforms suspended above the tanks. Wanting to get away from the repulsive smell that permeates this place, you get moving.<br /><br />As you walk into the darkness, you wonder what purpose this place once served... And what you might find here."
            };
            RoomTwo = new Room() {
                Name = "Industrial Complex", 
                FlavorText = "A wave of heat washes over you the moment you step through the door, making your skin sting and your eyes water. Shielding yourself as best you can, you take in the sight.<br /><br />Unlike most locations you have seen since entering this place, the purpose of this room is clear at a glance.<br /><br />Massive industrial machines work tirelessly, sending out pulses of heat with every action. Pipes of glowing light transport materials between machines. The machines themselves are incomprehensible to you, even if they seem perfectly suited to their purposes.<br /><br />From raw materials, ready to be processed, to finished products, poised for relocation to wherever they are meant to go.<br /><br />It is clear, however, that this place was not built for humans. Every step is a gamble, each moment spent timing the colossal machines carefully to avoid being crushed or blasted to dust by thermal vents.<br /><br />In the distance, you hear movement that feels distinctly different from the towering constructors. Something alive moves among the machines. You are not alone."
            };
            EnemyOne = new Enemy() {
                Name = "Mechanical Abomination", 
                FlavorText = "Lumbering footsteps echo through the air, coupled with a sharp scraping. A massive figure looms over you, its single, glowing red orb fixated on you with malevolent focus.<br /><br />The body is an insult against life.<br /><br />Jagged edges and sharp corners blend seamlessly into smooth, almost organic lines. The nightmarish figure moves with a grace no machine should ever possess.<br /><br />The translucent metal roils and shifts like real muscle with every motion the abomination makes as it stalks closer, every step measured by a mind far beyond any human's.<br /><br />Claws of collapsed space-time slice through the indestructible floor like butter as it flexes. A maw, filled to the brim with atom-thin fangs and dripping with acidic fluids, opens in a snarl. For all that you know it is naught but a machine, it looks like the maw of a true predator. One that has finally encountered prey after untold years without.<br /><br />The metallic monstrosity prepares to lunge."
            };
        }

        public IActionResult IntroScreen()
        {
            return View();
        }

        public IActionResult RoomScreen(Room room)
        {
            return View(room);
        }

        public IActionResult CombatScreen(Enemy enemy)
        {
            return View(enemy);
        }

        public IActionResult LoadPartial()
        {
            return PartialView("_InventoryScreen");
        }

        public IActionResult RestPartial()
        {
            return PartialView("_RestScreen");
        }

        public IActionResult LootPartial()
        {
            return PartialView("_LootScreen");
        }

        [HttpPost]
        public IActionResult Start()
        {
            //var result = _api.StartGame();
            //Console.WriteLine(result);
            CurrentRoom = RoomOne;
            HttpContext.Session.SetString("CurrentRoom", "RoomOne");
            return RedirectToAction("RoomScreen", RoomOne);
        }

        [HttpPost]
        public IActionResult Stop()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Continue()
        {
            var room = HttpContext.Session.GetString("CurrentRoom");
            if (room.Equals("RoomOne"))
            {
                HttpContext.Session.SetString("CurrentRoom", "RoomTwo");
                return RedirectToAction("RoomScreen", RoomTwo);
            } else
            {
                HttpContext.Session.SetString("CurrentRoom", "RoomOne");
                return RedirectToAction("RoomScreen", RoomOne);
            }
        }

        [HttpPost]
        public IActionResult Loot()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Rest()
        {
            return RedirectToAction("RoomScreen");
        }

        [HttpPost]
        public IActionResult Attack()
        {
            return Json(new
            {
                log = $"You strike! {EnemyOne.Name} took 999 damage!",
                logReturn = $"{EnemyOne.Name} strikes back! You took 9999 damage"
            });
        }
        
        [HttpPost]
        public IActionResult Flee()
        {

            var room = HttpContext.Session.GetString("CurrentRoom");
            if (room.Equals("RoomOne"))
            {
                return RedirectToAction("RoomScreen", RoomOne);
            }
            else
            {
                return RedirectToAction("RoomScreen", RoomTwo);
            }
        }

        [HttpPost]
        public IActionResult Explore()
        {
            return RedirectToAction("CombatScreen", EnemyOne);
        }
    }

    public class Room
    {
        public string Name { get; set; }
        public string FlavorText { get; set; }
    }

    public class Enemy
    {
        public string Name { get; set; }
        public string FlavorText { get; set; }
    }
}
