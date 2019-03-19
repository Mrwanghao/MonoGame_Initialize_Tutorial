using Nez;
using Utils;

namespace GameController
{
    public class MapController : Component
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

        public override void initialize()
        {
            base.initialize();

            InitializeMap();
        }

        private void InitializeMap()
        {
            this.Height = Globals.DEFAULT_MAP_HEIGHT;
            this.Width = Globals.DEFAULT_MAP_WIDTH;

            for(int row = 0; row < Height; row++)
            { 
                for(int col = 0; col < Width; col++)
                {
                    Debug.log(string.Format("row : {0}, col : {1}", row, col));
                }

            }

        }

    }
}
