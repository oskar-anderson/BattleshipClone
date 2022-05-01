using Domain.Model;
using Game;

namespace BlazorApp;

public class BlazorBattle : BaseBattleship
{
    public BlazorBattle(GameData gameData) : base(gameData)
    {
        Initialize();
    }

    public BlazorBattle(int boardHeight, int boardWidth, string ships, int allowAdjacentPlacement, int startingPlayerType, int secondPlayerType)
        : base(boardHeight, boardWidth, ships, allowAdjacentPlacement, startingPlayerType, secondPlayerType)
    {
        Initialize();
    }

    private void Initialize()
    {

    }
    
}