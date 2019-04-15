using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Utils;
using System.Collections.Generic;
using Components;
using ResourcesManager;

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

        public Entity Build(string fileName)
        {
            var ret = EntityFactory.Create(EntityFactory.EntityType.Builder);
            var sprite = ret.addComponent(new Sprite(Core.content.Load<Texture2D>(fileName)));
            sprite.setColor(Color.Blue);
            sprite.layerDepth = LayerManager.BUILDER_LAYER_DEPTH;
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
        }

        public void StartBuildOrEndBuild()
        {
            IsBuilding = !IsBuilding;
            if(IsBuilding == true)
            {
                StartBuild();
            }
            else
            {
                EndBuild();
            }
        }

        private void StartBuild()
        {
            _theEntityIsBuilding = Build(TextureCacheContext.WHITE_BLOCK_NAME);
        }

        private void EndBuild()
        {
            _theEntityIsBuilding.destroy();
        }
    }
}
