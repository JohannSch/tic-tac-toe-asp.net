using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GameLogic.Enums;
using GameLogic.GameObjects;

namespace GameLogic
{
    public static class Game
    {
        public static Cell[,] Cells;
        private static readonly string[,] _winCombinations = new string[,]
        {
            {"A1", "A2", "A3"},
            {"B1", "B2", "B3"},
            {"C1", "C2", "C3"},
            {"A1", "B1", "C1"},
            {"A2", "B2", "C2"},
            {"A3", "B3", "C3"},
            {"A1", "B2", "C3"},
            {"A3", "B2", "C1"}
        };

        public static void Initialize()
        {
            Cells = new Cell[3, 3];
            int i = 1;

            for (int x = 0; x < Cells.GetLength(0); ++x)
            {
                for (int y = 0; y < Cells.Length / Cells.GetLength(0); ++y)
                {
                    Cells[x, y] = new Cell();
                    Cells[x, y].CellState = CellState.Emptiness;
                    Cells[x, y].CellLocation = (CellLocation)i;
                    i++;
                }
            }
        }

        public static CellState SetCell(string cellLocation, bool isComputerFirst, bool isComputerStep)
        {
            foreach (var cell in Cells)
            {
                if (cell.ToString().Equals(cellLocation))
                {
                    if ((isComputerFirst && isComputerStep) 
                        || (!isComputerFirst && !isComputerStep))
                    {
                        cell.CellState = CellState.X;
                        return cell.CellState;
                    }
                    else
                    {
                        cell.CellState = CellState.O;
                        return cell.CellState;
                    }
                }
            }

            return CellState.Emptiness;
        }

        public static string MakeComputerStep(bool isComputerFirst)
        {
            var result = CheckWinningCombination(isComputerFirst);

            if (result != null)
                return result;

            return String.Empty;
        }

        private static string CheckWinningCombination(bool isComputerFirst)
        {
            List<CellState> cellStates = new List<CellState>();

            for (int i = 0; i < _winCombinations.GetLength(0); ++i)
            {
                cellStates.Clear();
                for (int y = 0; y < _winCombinations.Length / _winCombinations.GetLength(0); ++y)
                {
                    cellStates.Add(GetCellState(_winCombinations[i, y]));
                }

                if (IsAttackCombination(cellStates, isComputerFirst))
                {
                    var location =  GetEmptyCell(GetArrayRowByNumber(_winCombinations, i));

                    if (location != String.Empty)
                        return location;
                }
            }

            for (int i = 0; i < _winCombinations.GetLength(0); ++i)
            {
                cellStates.Clear();
                for (int y = 0; y < _winCombinations.Length / _winCombinations.GetLength(0); ++y)
                {
                    cellStates.Add(GetCellState(_winCombinations[i, y]));
                }

                if (IsDefenderCombination(cellStates, isComputerFirst))
                {
                    var location = GetEmptyCell(GetArrayRowByNumber(_winCombinations, i));

                    if (location != String.Empty)
                        return location;
                }
            }

            return GetRandomCellLocation();
        }

        public static bool IsGameOver()
        {
            List<CellState> cellStates = new List<CellState>();

            for (int i = 0; i < _winCombinations.GetLength(0); ++i)
            {
                cellStates.Clear();
                for (int y = 0; y < _winCombinations.Length / _winCombinations.GetLength(0); ++y)
                {
                    cellStates.Add(GetCellState(_winCombinations[i, y]));
                }

                if (IsWin(cellStates))
                    return true;
            }

            return false;
        }

        private static bool IsWin(List<CellState> cellStates)
        {
            if ((cellStates.Count(x => x == CellState.X) == 3)
                || (cellStates.Count(x => x == CellState.O) == 3))
                return true;

            return false;
        }

        private static CellState GetCellState(string cellLocation)
        {
            foreach (var cell in Game.Cells)
            {
                if (cell.ToString() == cellLocation)
                    return cell.CellState;
            }

            return CellState.Emptiness;
        }

        private static bool IsAttackCombination(List<CellState> cellStates, bool isComputerFirst)
        {
            if (isComputerFirst)
            {
                if (cellStates.Count(x => x == CellState.X) > 1)
                    return true;
            }
            else if (!isComputerFirst)
            {
                if (cellStates.Count(x => x == CellState.O) > 1)
                    return true;
            }

            return false;
        }

        private static bool IsDefenderCombination(List<CellState> cellStates, bool isComputerFirst)
        {
            if (isComputerFirst)
            {
                if (cellStates.Count(x => x == CellState.O) > 1)
                    return true;
            }
            else if (!isComputerFirst)
            {
                if (cellStates.Count(x => x == CellState.X) > 1)
                    return true;
            }

            return false;
        }

        private static string GetEmptyCell(string[] cellLocations)
        {
            foreach (var cellLocation in cellLocations)
            {
                if (GetCellState(cellLocation) == CellState.Emptiness)
                    return cellLocation;
            }

            return String.Empty;
        }

        private static string[] GetArrayRowByNumber(string[,] array, int i)
        {
            string[] newArray = new []{"", "", ""};

            for (int x = 0; x < array.Length / array.GetLength(0); ++x)
            {
                newArray[x] = array[i, x];
            }

            return newArray;
        }

        private static string GetRandomCellLocation()
        {
            List<CustomDictionary> xAndY = new List<CustomDictionary>();

            for (int y = 0; y < Cells.GetLength(0); ++y)
            {
                for (int x = 0; x < Cells.Length / Cells.GetLength(0); ++x)
                {
                    if (Cells[y, x].CellState == CellState.Emptiness)
                    {
                        xAndY.Add(new CustomDictionary(y, x));
                    }
                }
            }

            if (xAndY.Count != 0)
            {
                Random rndY = new Random();
                Random rndX = new Random();

                int y = rndY.Next(0, 3);
                int x = rndX.Next(0, 3);

                while (!xAndY.Any(i => i.X == x && i.Y == y))
                {
                    y = rndY.Next(0, 3);
                    x = rndX.Next(0, 3);
                }

                return Cells[y, x].ToString();
            }

            return String.Empty;
        }

        public static bool IsDraw()
        {
            for (int x = 0; x < Cells.GetLength(0); ++x)
            {
                for (int y = 0; y < Cells.Length / Cells.GetLength(0); ++y)
                {
                    if (Cells[x, y].CellState == CellState.Emptiness)
                        return false;
                }
            }

            return true;
        }

        private class CustomDictionary
        {
            public int X { get; set; }
            public int Y { get; set; }

            public CustomDictionary(int y, int x)
            {
                X = x;
                Y = y;
            }
        }
    }
}
