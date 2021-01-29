using System.Collections.Generic;

namespace DAL.Models
{
    public class GameSteps
    {
        public int Id { get; set; }
        public string Сharacter { get; set; }
        public string Cell { get; set; }

        public int GameResultId { get; set; }
        public GameResults GameResult { get; set; }
    }
}
