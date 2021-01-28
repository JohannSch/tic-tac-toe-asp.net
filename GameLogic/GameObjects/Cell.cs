using System;
using System.Collections.Generic;
using System.Text;
using GameLogic.Enums;

namespace GameLogic.GameObjects
{
    public class Cell
    {
        public CellState CellState { get; set; }

        public CellLocation CellLocation { get; set; }

        public override string ToString()
        {
            return Enum.GetName(typeof(CellLocation), CellLocation);
        }
    }
}
