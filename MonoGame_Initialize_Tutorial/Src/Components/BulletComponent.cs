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
            Core.schedule(1.0f, DestroySelf);
        }

        private void DestroySelf(ITimer timer)
        {
            entity.destroy();
            Debug.log("destroy {0}", Core.scene.entities.count);
        }

        public void update()
        {
            transform.position += Direction * Time.deltaTime * Speed;
        }
    }
}
