using Utils;

namespace GameController
{
    public class MapController
    {
        private MapLoader _mapLoader;

        public MapController()
        {
            _mapLoader = new MapLoader();
        }

        public void Save()
        {
            if(_mapLoader != null)
            { 
                _mapLoader.Save();
            }
        }

    }
}
