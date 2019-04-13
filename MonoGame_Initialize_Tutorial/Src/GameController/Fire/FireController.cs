using Nez;
using Microsoft.Xna.Framework;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;

namespace GameController
{
    public class FireController
    {
        private static FireController _instance;
        public static FireController Instance
        {
            get 
            { 
                if(_instance == null)
                {
                    _instance = new FireController();
                }
                return _instance;
            }
        }


        private bool _isFire = false;
        public bool IsFire 
        { 
            set { _isFire = value; }
            get { return _isFire; }
        }
        private bool _canFire = true;

        public void Update()
        { 
            if(IsFire)
            {
                Fire();

                IsFire = false;
            }
        }

        public void SendMessageToFire()
        { 
            if(_canFire)
            {
                IsFire = true;
            }
        }

        private void Fire()
        {
            Vector2 startPosition = BattleModule.Battle.Instance.PlayerControllerTargetPosition;
            Vector2 mousePosition = Vector2Ext.transform(Input.mousePosition, Core.scene.camera.inverseTransformMatrix);
            //Vector2 mousePosition = Input.mousePosition;
            var bullet = Core.scene.createEntity("bullet");
            var sprite_componnet = bullet.addComponent(new Nez.Sprites.Sprite(Core.content.Load<Texture2D>(Utils.TextureCacheContext.BLACK_BLOCK_NAME)));
            var bullet_component = bullet.addComponent<Components.BulletComponent>();
            var offset = mousePosition - startPosition;
            offset.Normalize();
            bullet_component.Direction = offset;

            bullet.addComponent(new BoxCollider(sprite_componnet.bounds.x,
                                                sprite_componnet.bounds.y,
                                                sprite_componnet.bounds.width,
                                                sprite_componnet.bounds.height
                ));

            bullet.transform.position = startPosition;
        }
    }
}
