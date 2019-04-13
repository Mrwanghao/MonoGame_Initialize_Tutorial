using Nez;
using Microsoft.Xna.Framework;
using Nez.Timers;

namespace Components
{
    public class BulletComponent : Component, IUpdatable
    {
        private Vector2 _direction;
        private float _speed;

        public Vector2 Direction
        {
            set { _direction = value; }
            get { return _direction; }
        }

        public float Speed
        {
            set { _speed = value; }
            private get { return _speed; }
        }

        public override void initialize()
        {
            base.initialize();
            Speed = 500.0f;
            //Core.schedule(1.0f, DestroySelf);
        }

        //private void DestroySelf(ITimer timer)
        //{
        //    entity.destroy();
        //    Debug.log("destroy {0}", Core.scene.entities.count);
        //}
        private BoxCollider _boxCollider;
        public BoxCollider BulletCollider
        {
            get
            {
                if (_boxCollider == null)
                {
                    _boxCollider = entity.getComponent<BoxCollider>();
                }
                return _boxCollider;
            }
        }

        public void update()
        {
            transform.position += Direction * Time.deltaTime * Speed;

            //var box_collider = bullet.getComponent<BoxCollider>();
            CollisionResult result;
            if (BulletCollider.collidesWithAny(out result))
            {
                Debug.log("name = {0}", result.collider.entity.name);
                entity.destroy();

            }
        }


    }
}
