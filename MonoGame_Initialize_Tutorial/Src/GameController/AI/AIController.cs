using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace GameController
{
    public class AIController
    {
        private Entity aiEntity;
        private Vector2 aiMoveDirection = new Vector2(0.0f, 1.0f);

        public AIController()
        {
            Initialize();
        }

        private void Initialize()
        {
            aiEntity = Core.scene.createEntity("AI");
            aiEntity.addComponent(new Sprite(Core.content.Load<Texture2D>(Utils.TextureCacheContext.BLACK_BLOCK_NAME)));

        }

        public void Update()
        {
            if (aiEntity == null) 
            {
                return;
            }

            aiEntity.transform.position += aiMoveDirection * Time.deltaTime * 500.0f;
            if(aiEntity.transform.position.Y > Core.scene.camera.bounds.bottom)
            {
                //aiEntity.destroy();
                Debug.log("Destroy Self");
            }
        }

    }
}
