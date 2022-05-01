using Domain.Model;
using Game;

namespace BlazorApp;

public class BlazorUpdateLogic : UpdateLogic
{
    private readonly Input Input;

    public BlazorUpdateLogic(Input input)
    {
        Input = input;
    }
    
    public override bool Update(double deltaTime, BaseBattleship basegame)
    {
        basegame.GameData.Input = Input;
        return base.Update(deltaTime, basegame);
    }
}