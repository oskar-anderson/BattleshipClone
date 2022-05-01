using Domain.Model;
using Domain.Tile;
using Game;

namespace BlazorApp;

public class BlazorDrawLogic
{
    public static TileData.CharInfo[,] GetDraw(double deltaTime, GameData gameData)
    {
        BaseDraw.Draw(deltaTime, gameData);
        TileData.CharInfo[,] map = new TileData.CharInfo[40, 40];
        BaseDraw.GetDrawArea(gameData, ref map);
        return map;
    }
}