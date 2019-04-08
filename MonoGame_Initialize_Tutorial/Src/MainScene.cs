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


        //DirectoryInfo info = new DirectoryInfo("/Users/wanghao/Documents/GitHub/MonoGame_Initialize_Tutorial/MonoGame_Initialize_Tutorial/bin/Debug/MonoGame_Initialize_Tutorial.app/Contents/Resources/stardrew/Animatardrew/Animals");
        //FileInfo[] files = info.GetFiles();
        ////string[] files = Directory.GetFiles("sCould not find a part of the path '/Users/wanghao/Documents/GitHub/MonoGame_Initialize_Tutorial/MonoGame_Initialize_Tutorial/bin/Debug/MonoGame_Initialize_Tutorial.app/Contents/Resources/stardrew/Animatardrew/Animals");

        //foreach(var filename in files)
        //{
        //    Texture2D texture = Core.scene.content.Load<Texture2D>(filename.Name);

        //    string name = texture.Name;
        //    int last_divide_operator_index = name.LastIndexOf('/');
        //    int length = name.Length - last_divide_operator_index;
        //    Stream S = new FileStream(texture.Name.Substring(last_divide_operator_index + 1, length - 1) + ".png", FileMode.Create);
        //    texture.SaveAsPng(S, texture.Width, texture.Height);
        //}

        Texture2D texture = Core.scene.content.Load<Texture2D>("stardrew/Animals/BabyBrown Chicken");

        string name = texture.Name;
        int last_divide_operator_index = name.LastIndexOf('/');
        int length = name.Length - last_divide_operator_index;
        Stream S = new FileStream(texture.Name.Substring(last_divide_operator_index + 1, length - 1) + ".png", FileMode.Create);
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

