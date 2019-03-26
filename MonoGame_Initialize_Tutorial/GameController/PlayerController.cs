using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Utils;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace GameController
{
    public class PlayerController
    {
        public PlayerController()
        {
            Initialize();    
        }

        private Entity _playerEntity;
        private PlayerInformation _playerInformation;

        private void Initialize()
        {
            _playerEntity = Core.scene.createEntity("Player");
            FollowCamera fc = new FollowCamera(_playerEntity, Core.scene.camera);
            _playerEntity.addComponent(fc);
            var sprite = _playerEntity.addComponent(new Sprite(Core.content.Load<Texture2D>(TextureCacheContext.DEFAULT_TILE_NAME)));
            sprite.layerDepth = LayerManager.PLAYER_LAYER_DEPTH;
            _playerEntity.transform.position = Globals.WINDOW_CENTER;
            _playerInformation = new PlayerInformation();
            
        }

        private Vector2 _moveDirection = Vector2.Zero;

        private Dictionary<Keys, Vector2> PlayerMoveDirections = new Dictionary<Keys, Vector2>()
        {
            {Keys.W, new Vector2(0.0f, -1.0f)},
            {Keys.D, new Vector2(1.0f, 0.0f)},
            {Keys.S, new Vector2(0.0f, 1.0f)},
            {Keys.A, new Vector2(-1.0f, 0.0f)},
        };

        public void Update()
        {
            UpdatePlayerControllerDirection();

            _playerEntity.transform.position += _moveDirection * _playerInformation.MoveSpeed; ;

            //BUILD 
            Build.BuildController.Update();
        }

        private void UpdatePlayerControllerDirection()
        {
            PlayerInput.Update();

            if (PlayerInput.IsMoveInputing == false)
            {
                _moveDirection = Vector2.Zero;
            }
            else
            {
                _moveDirection = Vector2.Zero;

                if (PlayerInput.IsMoveInputingHoriontal == true)
                {
                    _moveDirection = PlayerMoveDirections[PlayerInput.CurHoriontalDownKeys];
                }

                if (PlayerInput.IsMoveInputingVertical == true)
                {
                    _moveDirection += PlayerMoveDirections[PlayerInput.CurVerticalDownKeys];
                }

                _moveDirection.Normalize();
            }


        }

        static class PlayerInput
        {
            private static bool _isMoveInputingVertical = false;
            public static bool IsMoveInputingVertical
            {
                get { return _isMoveInputingVertical; }
                set 
                { 
                    _isMoveInputingVertical = value;
                    if (_isMoveInputingVertical | _isMoveInputingHoriontal == true)
                    {
                        IsMoveInputing = true;
                    }
                    else
                    {
                        IsMoveInputing = false;
                    }
                }
            }

            private static bool _isMoveInputingHoriontal = false;
            public static bool IsMoveInputingHoriontal
            {
                get { return _isMoveInputingHoriontal; }
                set 
                { 
                    _isMoveInputingHoriontal = value;
                    if (_isMoveInputingVertical | _isMoveInputingHoriontal == true) 
                    {
                        IsMoveInputing = true;
                    }
                    else
                    {
                        IsMoveInputing = false;
                    }
                }
            }

            private static bool _isMoveInputing = false;
            public static bool IsMoveInputing
            { 
                get { return _isMoveInputing; }
                set { _isMoveInputing = value; }
            }

            public static Keys CurVerticalDownKeys;
            public static Keys CurHoriontalDownKeys;

            public static void Update()
            {
                //都按下了
                if (IsMoveInputingVertical == true && IsMoveInputingHoriontal == true)
                {
                    if (Input.isKeyReleased(CurVerticalDownKeys))
                    {
                        IsMoveInputingVertical = false;
                    }

                    if (Input.isKeyReleased(CurHoriontalDownKeys))
                    {
                        IsMoveInputingHoriontal = false;
                    }
                }
                else if (IsMoveInputingVertical == true && IsMoveInputingHoriontal == false)
                {
                    if (Input.isKeyDown(Keys.D))
                    {
                        CurHoriontalDownKeys = Keys.D;
                        IsMoveInputingHoriontal = true;
                    }
                    else if (Input.isKeyDown(Keys.A))
                    {
                        CurHoriontalDownKeys = Keys.A;
                        IsMoveInputingHoriontal = true;
                    }

                    if (Input.isKeyReleased(CurVerticalDownKeys))
                    {
                        IsMoveInputingVertical = false;
                    }
                }
                else if (IsMoveInputingVertical == false && IsMoveInputingHoriontal == true) 
                {
                    if (Input.isKeyDown(Keys.W))
                    {
                        CurVerticalDownKeys = Keys.W;
                        IsMoveInputingVertical = true;
                    }
                    else if (Input.isKeyDown(Keys.S))
                    {
                        CurVerticalDownKeys = Keys.S;
                        IsMoveInputingVertical = true;
                    }

                    if (Input.isKeyReleased(CurHoriontalDownKeys))
                    {
                        IsMoveInputingHoriontal = false;
                    }
                }
                else
                {
                    if (Input.isKeyDown(Keys.W))
                    {
                        CurVerticalDownKeys = Keys.W;
                        IsMoveInputingVertical = true;
                    }
                    else if (Input.isKeyDown(Keys.S))
                    {
                        CurVerticalDownKeys = Keys.S;
                        IsMoveInputingVertical = true;
                    }

                    if (Input.isKeyDown(Keys.D))
                    {
                        CurHoriontalDownKeys = Keys.D;
                        IsMoveInputingHoriontal = true;
                    }
                    else if (Input.isKeyDown(Keys.A))
                    {
                        CurHoriontalDownKeys = Keys.A;
                        IsMoveInputingHoriontal = true;
                    }
                }

            }
        }

    }
}
