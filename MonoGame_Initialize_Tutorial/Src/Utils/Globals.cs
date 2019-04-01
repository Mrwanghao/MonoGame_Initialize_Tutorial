using Microsoft.Xna.Framework;


namespace Utils
{
    public class Globals
    {
        public static int DEFAULT_MAP_WIDTH = 16;
        public static int DEFAULT_MAP_HEIGHT = 16;

        public static int WINDOW_DEFAULT_WIDTH = 800;
        public static int WINDOW_DEFAULT_HEIGHT = 600;

        public static Vector2 WINDOW_CENTER = new Vector2(WINDOW_DEFAULT_WIDTH, WINDOW_DEFAULT_HEIGHT) / 2.0f;


        public static string MAP_CACHE_FILENAME = "map_cache.xml";
    }
}
