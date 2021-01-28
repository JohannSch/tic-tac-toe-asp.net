using System.ComponentModel;

namespace GameLogic.Enums
{
    public enum GameState
    {
        [Description("You won!")]
        Win = 0,

        [Description("You lose!")]
        Losing = 1
    }
}
