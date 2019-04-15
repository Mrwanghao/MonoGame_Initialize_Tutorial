using System;
using System.Diagnostics.Contracts;
using Components;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace ResourcesManager
{
    public class EntityFactory
    {
        public enum EntityType 
        { 
            Bullet,
            Builder
        }

        public static Entity Create(EntityType type)
        {
            Entity entity = null;
            switch(type)
            {
                case EntityType.Bullet:
                    entity = CreateBullet();
                    break;

                case EntityType.Builder:
                    entity = CreateBuilder();
                    break;
            }

            return entity;
        }

        private static Entity CreateBuilder()
        {
            var ret = Core.scene.createEntity("Builder");
            //var sprite = ret.addComponent(new Sprite(Core.content.Load<Texture2D>(fileName)));
            //sprite.setColor(Color.Blue);
            //sprite.layerDepth = LayerManager.BUILDER_LAYER_DEPTH;
            ret.addComponent<BuilderFollow>();
            return ret;
        }

        public static Entity CreateBullet()
        {
            Entity bullet = Core.scene.createEntity("Bullet");

            var sprite_componnet = bullet.addComponent(new Nez.Sprites.Sprite(Core.content.Load<Texture2D>(Utils.TextureCacheContext.BLACK_BLOCK_NAME)));
            bullet.addComponent<BulletComponent>();

            bullet.addComponent(new BoxCollider(sprite_componnet.bounds.x,
                                                sprite_componnet.bounds.y,
                                                sprite_componnet.bounds.width,
                                                sprite_componnet.bounds.height
                ));

            return bullet;
        }
    }
}
