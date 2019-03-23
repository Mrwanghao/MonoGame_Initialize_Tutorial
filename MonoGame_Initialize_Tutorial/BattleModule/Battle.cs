using GameController;

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

        private MapController _mapController;
        private PlayerController _playerController;

        private static bool _isInit = false;
 
        public void Initialize()
        { 
            if(_isInit)
            {
                return;
            }

            _mapController = new MapController();
            _playerController = new PlayerController();
        }

        private GameState _gameState = GameState.Play;
        public GameState State
        { 
            set { _gameState = value; }
            get { return _gameState; }
        }

        public void Update()
        { 
            if(State != GameState.Play)
            {
                return;
            }

            if (_playerController != null)
            {
                _playerController.Update();
            }
        }
    }
}
