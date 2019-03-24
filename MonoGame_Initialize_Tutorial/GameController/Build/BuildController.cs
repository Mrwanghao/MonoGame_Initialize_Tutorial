using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Utils;
using System.Collections.Generic;

namespace GameController.Build
{
    public static class BuildController
    {
        public static Entity Build(string fileName)
        {
            var ret = Core.scene.createEntity("");
            var sprite = ret.addComponent(new Sprite(Core.content.Load<Texture2D>(fileName)));
            sprite.setColor(Color.Blue);
            sprite.layerDepth = 0.5f;
            ret.addComponent<BuilderFollow>();
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

        private static List<Entity> _builders = new List<Entity>();

        public static void Update()
        {
            if (IsBuilding == true) 
            {
                if (Input.leftMouseButtonPressed) 
                {
                    if(_theEntityIsBuilding != null)
                    {
                        _theEntityIsBuilding.removeComponent<BuilderFollow>();
                        _builders.Add(_theEntityIsBuilding);
                        _theEntityIsBuilding = null;

                        _theEntityIsBuilding = Build(TextureCacheContext.WHITE_BLOCK_NAME);
                        //IsBuilding = false;
                    }
                }
            }
            else
            {
                if (Input.isKeyPressed(Keys.D3)) 
                {
                    IsBuilding = true;

                    _theEntityIsBuilding = Build(TextureCacheContext.WHITE_BLOCK_NAME);
                    //_theEntityIsBuilding.addComponent<BuilderFollow>();
                }
            }
        }
    }
}
