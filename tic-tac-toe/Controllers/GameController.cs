using Microsoft.AspNetCore.Mvc;
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

        public JsonResult MakeStep(string cellLocation, bool isComputerFirst)
        {
            var cellState = Game.SetCell(cellLocation, isComputerFirst, false);
            var isWin = Game.IsGameOver();
            var isDraw = Game.IsDraw();
            string message = "you won!";

            return Json(new {cellLocation, cellState, isWin, message, isDraw });
        }

        public JsonResult ComputerGo(bool isComputerFirst)
        {
            string cellLocation = Game.MakeComputerStep(isComputerFirst);

            var cellState = Game.SetCell(cellLocation, isComputerFirst, true);
            var isWin = Game.IsGameOver();
            var isDraw = Game.IsDraw();
            string message = "you lose!";

            return Json(new { cellLocation, cellState, isWin, message, isDraw });
        }
    }
}
