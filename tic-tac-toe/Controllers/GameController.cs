using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GameLogic;
using DAL;
using DAL.Models;

namespace tic_tac_toe.Controllers
{
    public class GameController : Controller
    {
        private static GameContext _gameContext;
        public static int CurrentGameId { get; set; }

        public IActionResult StartGame()
        {
            Game.Initialize();

            _gameContext = new GameContext();

            _gameContext.GameResults.Add(new GameResults()
            {
                DateTime = DateTime.Now
            });

            _gameContext.SaveChanges();

            CurrentGameId = _gameContext.GameResults.OrderBy(x => x.Id).Last().Id;

            return View("Index");
        }

        public JsonResult MakeStep(string cellLocation, bool isComputerFirst)
        {
            _gameContext.GameSteps.Add(new GameSteps()
            {
                Сharacter = "You",
                Cell = cellLocation,
                GameResultId = CurrentGameId
            });

            var cellState = Game.SetCell(cellLocation, isComputerFirst, false);
            var isWin = Game.IsGameOver();
            var isDraw = Game.IsDraw();
            string message = "you won!";

            if (isWin)
                _gameContext.GameResults.First(x => x.Id == CurrentGameId).GameResult = "Victory";
            else if (isDraw)
                _gameContext.GameResults.First(x => x.Id == CurrentGameId).GameResult = "Draw";

            _gameContext.SaveChanges();
            return Json(new {cellLocation, cellState, isWin, message, isDraw });
        }

        public JsonResult ComputerGo(bool isComputerFirst)
        {
            string cellLocation = Game.MakeComputerStep(isComputerFirst);

            _gameContext.GameSteps.Add(new GameSteps()
            {
                Сharacter = "Computer",
                Cell = cellLocation,
                GameResultId = CurrentGameId
            });

            var cellState = Game.SetCell(cellLocation, isComputerFirst, true);
            var isWin = Game.IsGameOver();
            var isDraw = Game.IsDraw();
            string message = "you lose!";

            if (isWin)
                _gameContext.GameResults.First(x => x.Id == CurrentGameId).GameResult = "loss";
            else if (isDraw)
                _gameContext.GameResults.First(x => x.Id == CurrentGameId).GameResult = "Draw";

            _gameContext.SaveChanges();
            return Json(new { cellLocation, cellState, isWin, message, isDraw });
        }

        public JsonResult GetSteps(int gameResultId)
        {
            var gameSteps = _gameContext.GameSteps.Where(x => x.GameResultId == gameResultId);


            return Json(gameSteps);
        }
    }
}
