using Nez;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


/// <summary>
/// This is the main type for your game.
/// </summary>
public class MainGame : Core
{
    public MainGame() : base(800, 600, false, windowTitle:"Window Nez")
    {
        Core.debugRenderEnabled = true;
        Core.scene = new MainScene(); 
        Scene.setDefaultDesignResolution(800, 600, Scene.SceneResolutionPolicy.BestFit);
    }
}

