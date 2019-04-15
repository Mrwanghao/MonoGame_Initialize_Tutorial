using Nez;
using Microsoft.Xna.Framework;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using ResourcesManager;
using Components;

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
            else
            {
                IsFire = false;
            }
        }

        private void Fire()
        {
            Vector2 startPosition = BattleModule.Battle.Instance.PlayerControllerTargetPosition;
            Vector2 mousePosition = Vector2Ext.transform(Input.mousePosition, Core.scene.camera.inverseTransformMatrix);

            Entity bullet = EntityFactory.Create(EntityFactory.EntityType.Bullet);

            var offset = mousePosition - startPosition;
            offset.Normalize();
            var bullet_component = bullet.getOrCreateComponent<BulletComponent>();
            bullet_component.Direction = offset;

            bullet.transform.position = startPosition;
        }
    }
}
