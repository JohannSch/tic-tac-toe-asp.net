using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class GameResults
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string GameResult { get; set; }

        public List<GameSteps> GameSteps;

        public GameResults()
        {
            GameSteps = new List<GameSteps>();
        }
    }
}
