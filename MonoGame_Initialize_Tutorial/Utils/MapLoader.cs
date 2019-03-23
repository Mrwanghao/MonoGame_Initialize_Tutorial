using System.Collections.Generic;
using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;

namespace Utils
{
    public class MapLoader
    {
        private int _width;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        private int _height;
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        private List<Entity> _tiles = new List<Entity>();
        public List<Entity> Tiles
        {
            set { _tiles = value; }
            get { return _tiles; }
        }

        private Entity _mapRoot;

        public MapLoader()
        {
            Initialize();
        }

        private void Initialize()
        {
            _mapRoot = Core.scene.createEntity("Map Root");

            this.Height = Globals.DEFAULT_MAP_HEIGHT;
            this.Width = Globals.DEFAULT_MAP_WIDTH;

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    Entity tile = Core.scene.createEntity(string.Format("tile : ({0}, {1})", row, col));
                    string fileName = (row + col) % 2 == 0 ? TextureCacheContext.WHITE_BLOCK_NAME : TextureCacheContext.BLACK_BLOCK_NAME;
                    Sprite sprite = tile.addComponent(new Sprite(Core.content.Load<Texture2D>(fileName)));
                    tile.transform.scale = Vector2.One * 5;
                    tile.transform.position = new Vector2((col + 0.5f) * sprite.bounds.width, (row + 0.5f) * sprite.bounds.height);
                    tile.transform.setParent(_mapRoot.transform);
                    _tiles.Add(tile);
                }

            }

        }
    }
}
