using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Utils;
using Microsoft.Xna.Framework.Input;

namespace GameController
{
    public class PlayerController
    {
        public PlayerController()
        {
            Initialize();    
        }

        private Entity _playerEntity;

        private void Initialize()
        {
            _playerEntity = Core.scene.createEntity("Player");
            _playerEntity.addComponent(new Sprite(Core.content.Load<Texture2D>(TextureCacheContext.DEFAULT_TILE_NAME)));
            _playerEntity.transform.position = Globals.WINDOW_CENTER;
        }

        public void Update()
        { 
            if(Input.isKeyPressed(Keys.W))
            {
                Debug.log("Move forward.");
            }

        }

    }
}
