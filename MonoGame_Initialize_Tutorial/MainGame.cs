using Nez;
using Utils;


/// <summary>
/// This is the main type for your game.
/// </summary>
public class MainGame : Core
{
    public MainGame() : base(Globals.WINDOW_DEFAULT_WIDTH, Globals.WINDOW_DEFAULT_HEIGHT, false, windowTitle:"Window Nez")
    {
        Core.scene = new MainScene(); 
        Scene.setDefaultDesignResolution(Globals.WINDOW_DEFAULT_WIDTH, Globals.WINDOW_DEFAULT_HEIGHT, Scene.SceneResolutionPolicy.BestFit);
        Core.debugRenderEnabled = false;
    }
}

