﻿using Nez;

namespace MapEditor.Desktop
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MainGame : Core
    {
        public MainGame() : base(800, 600, false)
        {
            Core.scene = new MainScene();
            Scene.setDefaultDesignResolution(800, 600, Scene.SceneResolutionPolicy.BestFit);
        }

    }
}
