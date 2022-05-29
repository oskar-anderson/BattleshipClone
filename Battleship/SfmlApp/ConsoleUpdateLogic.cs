using Domain.Model;
using Game;
using SFML.Graphics;

namespace SfmlApp;

public class ConsoleUpdateLogic : UpdateLogic
{
    private readonly RenderWindow Window;

    public ConsoleUpdateLogic(RenderWindow window)
    {
        Window = window;
    }
    
    public override bool Update(double deltaTime, BaseBattleship basegame)
    {
        basegame.GameData.Input = Window.HasFocus() ? new ConsoleInput(Window).UpdateInput(basegame.GameData.Input) : Input.GetDefaultInput();
        return base.Update(deltaTime, basegame);
    }
}