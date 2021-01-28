using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLogic;

namespace tic_tac_toe.Controllers
{
    public class GameController : Controller
    {
        public IActionResult StartGame()
        {
            Game.Initialize();

            return View("Index");
        }
    }
}
