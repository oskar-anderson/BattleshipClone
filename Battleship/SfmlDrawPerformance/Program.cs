// See https://aka.ms/new-console-template for more information

using System.Numerics;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

// this is just a quick and dirty test - you have to place the font manually
Font font = new Font(AppDomain.CurrentDomain.BaseDirectory + "/PressStart2P.ttf");
var window = new RenderWindow(new VideoMode(960, 720), "Battleships");
window.Closed += (sender, e) =>
{
    window.Close();
};
window.SetFramerateLimit(0);
Console.OutputEncoding = Encoding.Unicode;
var width = 40;
var height = 40;
var chars = "zxcasdqwe";
var random = new Random();
var frameCount = 0;
while (true)
{
    // fps: 200
    window.Clear();
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            var text = new Text(
                chars[random.Next() % chars.Length].ToString(), 
                font)
            {
                Position = new Vector2f(
                    x * 16, 
                    y * 16), 
                CharacterSize = 16
            };
            window.Draw(text);
        }
    }

    frameCount++;
    window.Draw(new Text($"FrameCount: {frameCount}", font) 
    {
        Position = new Vector2f(40, 700),
        CharacterSize = 16
    });
    window.Display();
}

