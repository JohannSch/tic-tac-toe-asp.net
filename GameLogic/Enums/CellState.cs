using System.ComponentModel;

namespace GameLogic.Enums
{
    public enum CellState
    {
        [Description("The cell is empty")]
        Emptiness = 0,

        [Description("Delivered by \"X\"")]
        X = 1,

        [Description("Delivered by \"O\"")]
        O = 2
    }
}
