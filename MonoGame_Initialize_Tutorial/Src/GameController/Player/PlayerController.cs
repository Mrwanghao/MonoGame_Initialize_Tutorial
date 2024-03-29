﻿using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Utils;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using GameController.Build;

namespace GameController
{
    public class PlayerController
    {
        private Entity playerEntity;
        private PlayerInformation playerInformation;

        public PlayerController(Entity target, PlayerInformation information)
        {
            playerEntity = target;
            playerInformation = information;
        }

        private Dictionary<Keys, Vector2> PlayerMoveDirections = new Dictionary<Keys, Vector2>()
        {
            {Keys.W, new Vector2(0.0f, -1.0f)},
            {Keys.D, new Vector2(1.0f, 0.0f)},
            {Keys.S, new Vector2(0.0f, 1.0f)},
            {Keys.A, new Vector2(-1.0f, 0.0f)},
        };

        public void Update()
        {
            if (playerEntity == null) 
                return;
 
            PlayerInput.Instance.Update();

            UpdatePlayerControllerDirectionWithPlayerInput();

            //BUILD 
            BuildController.Instance.Update();
            FireController.Instance.Update();
        }

        private void UpdatePlayerControllerDirectionWithPlayerInput()
        {
            if (PlayerInput.Instance.IsMoveInputing == false)
            {
                return;
            }
            else
            {
                Vector2 _moveDirection = Vector2.Zero;

                if (PlayerInput.Instance.IsMoveInputingHoriontal == true)
                {
                    _moveDirection = PlayerMoveDirections[PlayerInput.Instance.CurHoriontalDownKeys];
                }

                if (PlayerInput.Instance.IsMoveInputingVertical == true)
                {
                    _moveDirection += PlayerMoveDirections[PlayerInput.Instance.CurVerticalDownKeys];
                }

                _moveDirection.Normalize();

                playerEntity.transform.position += _moveDirection * playerInformation.MoveSpeed; ;
            }

        }

        public class PlayerInput
        {
            private static PlayerInput _instance;
            public static PlayerInput Instance
            {
                get 
                { 
                    if(_instance == null)
                    {
                        _instance = new PlayerInput();
                    }
                    return _instance;
                }
            }

            private bool _isMoveInputingVertical = false;
            public bool IsMoveInputingVertical
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

            private bool _isMoveInputingHoriontal = false;
            public bool IsMoveInputingHoriontal
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

            private bool _isMoveInputing = false;
            public bool IsMoveInputing
            { 
                get { return _isMoveInputing; }
                set { _isMoveInputing = value; }
            }

            public Keys CurVerticalDownKeys;
            public Keys CurHoriontalDownKeys;

            public void Update()
            {
                if (Input.leftMouseButtonPressed)
                {
                    FireController.Instance.SendMessageToFire();
                }

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


                if(Input.isKeyPressed(Keys.D3))
                {
                    BuildController.Instance.StartBuildOrEndBuild();
                }



            }
        }

    }
}
