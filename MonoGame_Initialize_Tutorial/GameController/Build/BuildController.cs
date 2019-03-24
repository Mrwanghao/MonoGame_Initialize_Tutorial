using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Utils;

namespace GameController.Build
{
    public static class BuildController
    {
        public static Entity Build(string fileName)
        {
            var ret = Core.scene.createEntity("");
            var sprite = ret.addComponent(new Sprite(Core.content.Load<Texture2D>(fileName)));
            sprite.setColor(Color.Blue);
            return ret; 
        }

        private static bool _isBuilding = false;
        public static bool IsBuilding
        { 
            set 
            {
                _isBuilding = value;
            }
            get { return _isBuilding; }
        }

        private static Entity _theEntityIsBuilding;

        public static void Update()
        {
            if (IsBuilding == true) 
            {
                if (Input.isKeyPressed(Keys.D3)) 
                {
                    //_theEntityIsBuilding.re
                }
            }
            else
            {
                if (Input.isKeyPressed(Keys.D3)) 
                {
                    _theEntityIsBuilding = Build(TextureCacheContext.WHITE_BLOCK_NAME);
                    //willBuilder.transform.position
                    _theEntityIsBuilding.addComponent<BuilderFollow>();
                    //_theEntityIsBuilding
                }
            }
        }
    }
}
