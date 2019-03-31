using System;
using Nez;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;


namespace MapEditor
{
    public class DefaultMapTile
    {
        private Entity _entity;
        private Texture2D _texture;
        private Sprite _sprite;

        public DefaultMapTile()
        {
            _texture = new Texture2D(Core.graphicsDevice, 20, 20);

            float[] data = new float[1600];
            _texture.GetData<float>(data, 0, 400);

            for (int index = 0, size = data.Length; index < size; index++)
            {
                data[index] = 20;
            }
            _texture.SetData<float>(data, 0, 400);


            _entity = Core.scene.createEntity("");
            _sprite = _entity.addComponent(new Sprite(_texture));
            _entity.transform.position = new Vector2(200, 200);

        }
    }
}
