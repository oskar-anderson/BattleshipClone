using GLFW;



namespace OpenTKProj;

public class GLFW
{
    /*
     * Windows:
     * Unhandled exception. System.TypeInitializationException: The type initializer for 'GLFW.Glfw' threw an exception.
         ---> System.DllNotFoundException: Unable to load DLL 'glfw' or one of its dependencies: The specified module could not be found. (0x8007007E)

     * 
     */
    private const string TITLE = "Simple Window";
    private const int WIDTH = 1024;
    private const int HEIGHT = 800;

    private const int GL_COLOR_BUFFER_BIT = 0x00004000;


    private delegate void glClearColorHandler(float r, float g, float b, float a);
    private delegate void glClearHandler(int mask);

    private static glClearColorHandler glClearColor = default!;
    private static glClearHandler glClear = default!;

    private static Random rand = default!;
    
    public static void glfw(string[] args)
    {
        Glfw.WindowHint(Hint.ClientApi, ClientApi.OpenGL);
        Glfw.WindowHint(Hint.ContextVersionMajor, 3);
        Glfw.WindowHint(Hint.ContextVersionMinor, 3);
        Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);
        Glfw.WindowHint(Hint.Doublebuffer, true);
        Glfw.WindowHint(Hint.Decorated, true);
        Glfw.WindowHint(Hint.OpenglForwardCompatible, true);

        rand = new Random();


        // The object oriented approach
        using (var window = new NativeWindow(WIDTH, HEIGHT, "title"))
        {
            window.CenterOnScreen();
            window.KeyPress += WindowOnKeyPress;
            while (!window.IsClosing)
            {
                Glfw.PollEvents();
                window.SwapBuffers();
            }
        }

    }
    
    private static void WindowOnKeyPress(object? sender, KeyEventArgs e)
    {
        var window = (NativeWindow) sender!;
        switch (e.Key)
        {
            case Keys.Escape:
                window.Close();
                break;
            // ...and so on....
        }
    }
}