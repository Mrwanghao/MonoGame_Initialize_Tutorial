using GameController;

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
        private PlayerController _playerController;
        #endregion

        #region life cycle
        public void Initialize()
        { 
            if(_isInit)
            {
                return;
            }

            _mapController = new MapController();
            _playerController = new PlayerController();
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

            if (Nez.Input.isKeyPressed(Keys.P))
            {
                _mapController.Save();
            }
        }
        #endregion
    }
}
