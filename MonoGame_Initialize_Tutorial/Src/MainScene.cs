using Microsoft.Xna.Framework;
using Nez;
using GameController;
using BattleModule;
using UI;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

public class MainScene : Scene
{

    public MainScene()
    {
        addRenderer(new DefaultRenderer());
    }

    public override void initialize()
    {
        base.initialize();

    }

    public override void onStart()
    {
        base.onStart();

        Core.scene.clearColor = Color.Beige;
        Battle.Instance.Initialize();

        Stream S = new FileStream("bathhouse_tiles.png", FileMode.Create);
        Texture2D texture = Core.scene.content.Load<Texture2D>("stardrew/Animals/BabyBrown Cow");
        texture.SaveAsPng(S, texture.Width, texture.Height);


        UI.UIManager.Instance.Open("Game Window", new UI.GameWindow());
    }

    public override void unload()
    {
        base.unload();

    }

    public override void update()
    {
        base.update();

        Battle.Instance.Update();


        UIManager.Instance.Update();
    }
}        

