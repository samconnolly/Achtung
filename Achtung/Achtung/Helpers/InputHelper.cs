using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;


using Microsoft.Xna.Framework.Media;

namespace Achtung
{
    public static class InputHelper
    {
        private static KeyboardState _currentKeyState;
        private static GamePadState _currentGamePadStateP1;
        private static GamePadState _currentGamePadStateP2;
        private static GamePadState _currentGamePadStateP3;
        private static GamePadState _currentGamePadStateP4;
        private static KeyboardState _previousKeyState;
        private static GamePadState _previousGamePadStateP1;
        private static GamePadState _previousGamePadStateP2;
        private static GamePadState _previousGamePadStateP3;
        private static GamePadState _previousGamePadStateP4;
        
        private static int _players = 1;

        #region Properties - Public Static

        public static KeyboardState CurrentKeyState
        {
            get { return _currentKeyState; }
            set
            {
                _previousKeyState = _currentKeyState;
                _currentKeyState = value;
            }
        }
             

        public static GamePadState CurrentGamePadStatePlayer1
        {
            get { return _currentGamePadStateP1; }
            set
            {
                _previousGamePadStateP1 = _currentGamePadStateP1;
                _currentGamePadStateP1 = value;
            }
        }

        public static GamePadState PreviousGamePadStatePlayer1
        {
            get { return _previousGamePadStateP1; }
        }

        public static GamePadState CurrentGamePadStatePlayer2
        {
            get { return _currentGamePadStateP2; }
            set
            {
                _previousGamePadStateP2 = _currentGamePadStateP2;
                _currentGamePadStateP2 = value;
            }
        }


        public static GamePadState CurrentGamePadStatePlayer3
        {
            get { return _currentGamePadStateP3; }
            set
            {
                _previousGamePadStateP3 = _currentGamePadStateP3;
                _currentGamePadStateP3 = value;
            }
        }


        public static GamePadState CurrentGamePadStatePlayer4
        {
            get { return _currentGamePadStateP4; }
            set
            {
                _previousGamePadStateP4 = _currentGamePadStateP4;
                _currentGamePadStateP4 = value;
            }
        }

        public static int Players
        {
            get { return _players; }
            set { _players = value; }
        }

        #endregion

        #region Methods - Public Static
                
        public static bool IsButtonDown(Keys key)
        {
            bool down = false;

            if (CurrentKeyState.IsKeyDown(key))
            {
                down = true;
            }
            return down;
        }
        
        public static bool IsPadThumbstickLeft(int player)
        {
            bool pressed = false;
            if (player == 0 && CurrentGamePadStatePlayer1.ThumbSticks.Left.X < 0)
            {
                pressed = true;
            }
            if (player == 1 && CurrentGamePadStatePlayer2.ThumbSticks.Left.X < 0)
            {
                pressed = true;
            }
            if (player == 2 && CurrentGamePadStatePlayer3.ThumbSticks.Left.X < 0)
            {
                pressed = true;
            }
            if (player == 3 && CurrentGamePadStatePlayer4.ThumbSticks.Left.X < 0)
            {
                pressed = true;
            }
            return pressed;
        }

        public static bool IsPadThumbstickRight(int player)
        {
            bool pressed = false;
            if (player == 0 && CurrentGamePadStatePlayer1.ThumbSticks.Left.X > 0)
            {
                pressed = true;
            }
            if (player == 1 && CurrentGamePadStatePlayer2.ThumbSticks.Left.X > 0)
            {
                pressed = true;
            }
            if (player == 2 && CurrentGamePadStatePlayer3.ThumbSticks.Left.X > 0)
            {
                pressed = true;
            }
            if (player == 3 && CurrentGamePadStatePlayer4.ThumbSticks.Left.X > 0)
            {
                pressed = true;
            }
            return pressed;
        }

        public static bool WasPadThumbstickUpP1()
        {
            bool pressed = false;
            if (CurrentGamePadStatePlayer1.ThumbSticks.Left.Y > 0 && PreviousGamePadStatePlayer1.ThumbSticks.Left.Y == 0)
            {
                pressed = true;
            }
            return pressed;
        }

        public static bool WasPadThumbstickDownP1()
        {
            bool pressed = false;
            if (CurrentGamePadStatePlayer1.ThumbSticks.Left.Y < 0 && PreviousGamePadStatePlayer1.ThumbSticks.Left.Y == 0)
            {
                pressed = true;
            }
            return pressed;
        }

        public static bool WasPadButtonPressedP1(Buttons button)
        {
            bool pressed = false;
            if (CurrentGamePadStatePlayer1.IsButtonUp(button) && PreviousGamePadStatePlayer1.IsButtonDown(button))
            {
                pressed = true;
            }
            return pressed;
        }

        public static bool WasButtonPressed(Keys key)
        {
            bool pressed = false;
            if (CurrentKeyState.IsKeyUp(key) && PreviousKeyState.IsKeyDown(key))
            {
                pressed = true;
            }
            return pressed;
        }

        public static KeyboardState PreviousKeyState
        {
            get { return _previousKeyState; }
        }
        
        public static void SetKeyboardState()
        {
            CurrentKeyState = Keyboard.GetState();
        }

        public static void SetGamePadStatePlayer1()
        {
            CurrentGamePadStatePlayer1 = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One);
        }

        public static void SetGamePadStatePlayer2()
        {
            CurrentGamePadStatePlayer2 = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.Two);
        }

        public static void SetGamePadStatePlayer3()
        {
            CurrentGamePadStatePlayer2 = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.Three);
        }

        public static void SetGamePadStatePlayer4()
        {
            CurrentGamePadStatePlayer2 = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.Four);
        }
        
        #endregion
    }
}
