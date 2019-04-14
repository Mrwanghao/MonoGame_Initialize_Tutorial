using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Utils;
using System.Collections.Generic;
using Components;

namespace GameController.Build
{
    public class BuildController
    {
        private static BuildController _instance;
        public static BuildController Instance
        {
            get 
            {
                if (_instance == null) 
                {
                    _instance = new BuildController();
                }
                return _instance;
            }
        }


        //private FastList<Entity> _builderCache;


        public Entity Build(string fileName)
        {
            var ret = Core.scene.createEntity("Builder");
            var sprite = ret.addComponent(new Sprite(Core.content.Load<Texture2D>(fileName)));
            sprite.setColor(Color.Blue);
            sprite.layerDepth = LayerManager.BUILDER_LAYER_DEPTH;
            ret.addComponent<BuilderFollow>();
            return ret; 
        }

        private bool _isBuilding = false;
        public bool IsBuilding
        { 
            set 
            {
                _isBuilding = value;
            }
            get { return _isBuilding; }
        }

        private Entity _theEntityIsBuilding;

        private List<Entity> _builders = new List<Entity>();

        public void Update()
        {
            if (IsBuilding == true) 
            {
                if (Input.middleMouseButtonPressed) 
                {
                    if(_theEntityIsBuilding != null)
                    {
                        _theEntityIsBuilding.removeComponent<BuilderFollow>();
                        _builders.Add(_theEntityIsBuilding);
                        _theEntityIsBuilding = null;

                        _theEntityIsBuilding = Build(TextureCacheContext.WHITE_BLOCK_NAME);
                    }
                }
            }
            else
            {
                if (Input.isKeyPressed(Keys.D3)) 
                {
                    IsBuilding = true;

                    _theEntityIsBuilding = Build(TextureCacheContext.WHITE_BLOCK_NAME);
                }
            }
        }
    }
}
