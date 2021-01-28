using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GameLogic.Enums;
using GameLogic.GameObjects;

namespace GameLogic
{
    static public class Game
    {
        static public Cell[,] Cells;

        static public void Initialize()
        {
            Cells = new Cell[3, 3];
            int i = 1;

            for (int x = 0; x < 3; ++x)
            {
                for (int y = 0; y < 3; ++y)
                {
                    Cells[x, y] = new Cell();
                    Cells[x, y].CellState = CellState.Emptiness;
                    Cells[x, y].CellLocation = (CellLocation)i;
                    i++;
                }
            }
        }
    }
}
