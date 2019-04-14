using GameController;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BattleModule
{
    public enum GameState
    { 
        Play,
        Pause,
        Exit,
    }

    public class Battle
    {
        private static bool _isInit = false;

        #region Instance
        private static Battle _instance;
        public static Battle Instance
        {
            set { _instance = value; }
            get
            {
                if(_instance == null)
                {
                    _instance = new Battle();
                }
                return _instance;
            }
        }
        #endregion

        #region attribute
        private GameState _gameState = GameState.Play;
        public GameState State
        {
            set { _gameState = value; }
            get { return _gameState; }
        }

        private MapController _mapController;
        private Player mainPlayer;

        public Vector2 PlayerControllerTargetPosition
        { 
            get 
            { 
                if(mainPlayer != null)
                {
                    return mainPlayer.TargetPosition;
                }
                return Vector2.Zero;
            }
        }
        #endregion

        #region life cycle
        public void Initialize()
        { 
            if(_isInit)
            {
                return;
            }

            _mapController = new MapController();
            mainPlayer = new Player();

            _isInit = true;
        }

        private void _initialize()
        { 
        
        }

        public void Update()
        { 
            if(State != GameState.Play)
            {
                return;
            }

            if(mainPlayer != null)
            {
                mainPlayer.Update();
            }

        }
        #endregion
    }
}
