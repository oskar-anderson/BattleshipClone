// See https://aka.ms/new-console-template for more information

using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace OpenTKProj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GLFW.glfw(Array.Empty<string>());
            Console.WriteLine("Hello, World!");

            /* Linux:
             *
             * Unhandled exception. System.TypeInitializationException: The type initializer for 'OpenTK.Windowing.Desktop.NativeWindowSettings' threw an exception.
                ---> System.DllNotFoundException: Unable to load shared library 'glfw' or one of its dependencies. In order to help diagnose loading problems, consider setting the LD_DEBUG environment variable: libglfw: cannot open shared object file: No such file or directory
             * 
             */
            // https://github.com/opentk/opentk/issues/1064
            
            // Windows:
            // Unhandled exception. OpenTK.Windowing.GraphicsLibraryFramework.GLFWException: WGL: Driver does not support OpenGL version 4.7
            GameWindowSettings gws = GameWindowSettings.Default;
            NativeWindowSettings nws = NativeWindowSettings.Default;

            gws.IsMultiThreaded = false;
            gws.RenderFrequency = 60;
            gws.UpdateFrequency = 60;
            
            nws.APIVersion = Version.Parse("4.7.2");
            nws.Size = new Vector2i(1280, 720);
            nws.Title = "OpenTkApp";
            
            GameWindow window = new GameWindow(gws, nws);

            var playerX = 0;
            window.UpdateFrame += (FrameEventArgs args) =>
            {
                playerX++;
                Console.WriteLine($"{playerX}");

            };
            window.Run();
        }
    }
    
}

