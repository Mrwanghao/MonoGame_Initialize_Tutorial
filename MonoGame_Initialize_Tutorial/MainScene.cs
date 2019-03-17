using Microsoft.Xna.Framework;
using Nez;

    public class MainScene : Scene
    {

        public MainScene()
        {
            addRenderer(new DefaultRenderer());
        }

        public override void initialize()
        {
            base.initialize();

            //Debug.log(2);

        }

        public override void onStart()
        {
            base.onStart();
            //Debug.log(3);
            Core.scene.clearColor = Color.Black;
        }

        public override void unload()
        {
            base.unload();
        }

        public override void update()
        {
            base.update();
        }
    }

