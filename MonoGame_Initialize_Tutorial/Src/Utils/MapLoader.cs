using System.Collections.Generic;
using Nez;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez.Sprites;

using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System;

namespace Utils
{
    public class MapTilePosition
    {
        public int x;
        public int y;

        public MapTilePosition()
        { }

        public MapTilePosition(int col, int row)
        {
            x = col;
            y = row;
        }
    }

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

        private List<MapTilePosition> mapTilePositions = new List<MapTilePosition>();

        public MapLoader()
        {
            Initialize();
        }

        private void Initialize()
        {
            _mapRoot = Core.scene.createEntity("Map Root");

            if (!File.Exists(Globals.MAP_CACHE_FILENAME))
            {
                InitializeWithoutCache();
                return;
            }

            InitializeWithCache();

        }


        private void InitializeWithCache()
        {
            Load(Globals.MAP_CACHE_FILENAME);

            GenerateMapTilesWithMapTilePosition();
        }

        private void InitializeWithoutCache()
        {
            this.Height = Globals.DEFAULT_MAP_HEIGHT;
            this.Width = Globals.DEFAULT_MAP_WIDTH;

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    GenerateOneMapTileWithPosition(row, col);
                    mapTilePositions.Add(new MapTilePosition(col, row));
                }
            }

        }

        private void GenerateMapTilesWithMapTilePosition()
        {
            int maxX = -1;
            int maxY = -1;

            foreach (var mapTile in mapTilePositions)
            {
                GenerateOneMapTileWithPosition(mapTile.y, mapTile.x);
                maxX = maxX > mapTile.x ? maxX : mapTile.x;
                maxY = maxY > mapTile.y ? maxY : mapTile.y;
            }

            Width = maxX;
            Height = maxY;
        }

        private Entity GenerateOneMapTileWithPosition(int row, int col)
        {
            Entity tile = Core.scene.createEntity(string.Format("tile : ({0}, {1})", row, col));
            string fileName = (row + col) % 2 == 0 ? TextureCacheContext.WHITE_BLOCK_NAME : TextureCacheContext.BLACK_BLOCK_NAME;
            Sprite sprite = tile.addComponent(new Sprite(Core.content.Load<Texture2D>(fileName)));
            sprite.layerDepth = LayerManager.MAP_LAYER_DEPTH;
            tile.transform.scale = Vector2.One * 5;
            tile.transform.position = new Vector2((col + 0.5f) * sprite.bounds.width, (row + 0.5f) * sprite.bounds.height);
            tile.transform.setParent(_mapRoot.transform);
            Tiles.Add(tile);
            return tile;
        }

        public void Save()
        {
            Save(Globals.MAP_CACHE_FILENAME);
        }

        /// <summary>
        /// Save this instance to the xml file.
        /// </summary>
        private void Save(string fileName)
        {
            if(!File.Exists(fileName))
            {
                File.Create(fileName).Dispose();
            }

            using (var sw = new StreamWriter(new FileStream(fileName, FileMode.Truncate)))
            {
                var ser = new XmlSerializer(typeof(List<MapTilePosition>));
                ser.Serialize(sw, mapTilePositions);

            }
        }

        private void Load(string fileName)
        {
            using (var sr = new StreamReader(new FileStream(fileName, FileMode.Open)))
            {
                var ser = new XmlSerializer(typeof(List<MapTilePosition>));
                mapTilePositions.Clear();
                mapTilePositions = (List<MapTilePosition>)ser.Deserialize(sr);
            }
        }
    }
}
