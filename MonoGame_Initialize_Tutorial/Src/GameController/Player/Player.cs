using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Utils;

namespace GameController
{
    public class Player
    {
        private Entity playerEntity;
        private PlayerInformation playerInformation;
        private PlayerController playerController;

        public Player()
        {
            Initialize();
        }

        private void Initialize()
        {
            //entity
            playerEntity = Core.scene.createEntity("Player");
            playerEntity.addComponent(new FollowCamera(playerEntity, Core.scene.camera));
            var sprite = playerEntity.addComponent(new Sprite(Core.content.Load<Texture2D>(Utils.TextureCacheContext.DEFAULT_TILE_NAME)));
            sprite.layerDepth = Utils.LayerManager.PLAYER_LAYER_DEPTH;
            playerEntity.transform.position = Globals.WINDOW_CENTER;
            //player information
            playerInformation = new PlayerInformation();
            //player controller
            playerController = new PlayerController(playerEntity, playerInformation);
        }

        public Vector2 TargetPosition
        {
            get
            {
                if (playerEntity != null)
                {
                    return playerEntity.position;
                }
                return Vector2.Zero;
            }
        }

        internal void Update()
        {
            if(playerController != null)
            {
                playerController.Update();
            }
        }
    }
}
