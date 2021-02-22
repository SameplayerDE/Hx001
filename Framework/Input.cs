using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Hx001.Framework
{
    public static class Input
    {

        public static KeyboardState CurrentKeyboardState;
        public static KeyboardState PreviouseKeyboardState;

        public static MouseState CurrentMouseState;
        public static MouseState PreviouseMouseState;

        public static GamePadState[] CurrentGamepadStates = new GamePadState[4] { GamePad.GetState(0), GamePad.GetState(1), GamePad.GetState(2), GamePad.GetState(3) };
        public static GamePadState[] PreviouseGamepadStates = new GamePadState[4];
        #region Mouse
        public static bool IsLeftButtonDown { get { return IsLeftButtonEqualTo(ButtonState.Pressed); } }
        public static bool IsRightButtonDown { get { return IsRightButtonEqualTo(ButtonState.Pressed); } }
        public static bool IsLeftButtonUp { get { return IsLeftButtonEqualTo(ButtonState.Released); } }
        public static bool IsRightButtonUp { get { return IsRightButtonEqualTo(ButtonState.Released); } }
        public static bool WasLeftButtonDown { get { return WasLeftButtonEqualTo(ButtonState.Pressed); } }
        public static bool WasRightButtonDown { get { return WasRightButtonEqualTo(ButtonState.Pressed); } }
        public static bool WasLeftButtonUp { get { return WasLeftButtonEqualTo(ButtonState.Released); } }
        public static bool WasRightButtonUp { get { return WasRightButtonEqualTo(ButtonState.Released); } }
        public static bool IsLeftButtonPressed { get { return (IsLeftButtonDown && WasLeftButtonUp); } }
        public static bool IsRightButtonPressed { get { return (IsRightButtonDown && WasRightButtonUp); } }
        public static bool IsLeftButtonReleased { get { return (IsLeftButtonUp && WasLeftButtonDown); } }
        public static bool IsRightButtonReleased { get { return (IsRightButtonUp && WasRightButtonDown); } }
        #endregion

        public static float GetAxis(string key)
        {
            float result = 0;
            if (key == "Mouse X")
            {
                result = CurrentMouseState.X - PreviouseMouseState.X;
            }
            else if (key == "Mouse Y")
            {
                result = CurrentMouseState.Y - PreviouseMouseState.Y;
            }
            else if (key == "Horizontal")
            {
                bool left, right;
                left = CurrentKeyboardState.IsKeyDown(Keys.A);
                right = CurrentKeyboardState.IsKeyDown(Keys.D);
                if (right)
                {
                    result += 1;
                }
                if (left)
                {
                    result -= 1;
                }
            }
            else if (key == "Vertical")
            {

                bool up, down;
                up = CurrentKeyboardState.IsKeyDown(Keys.W);
                down = CurrentKeyboardState.IsKeyDown(Keys.S);
                if (up)
                {
                    result += 1;
                }
                if (down)
                {
                    result -= 1;
                }
            }
            return result;
        }

        public static void Update(GameTime gameTime)
        {
            RefreshStates();
        }

        private static void RefreshStates()
        {
            PreviouseKeyboardState = CurrentKeyboardState;
            PreviouseMouseState = CurrentMouseState;
            PreviouseGamepadStates = CurrentGamepadStates;

            CurrentKeyboardState = Keyboard.GetState();
            CurrentMouseState = Mouse.GetState();

            for (int i = 0; i < 4; i++)
            {
                CurrentGamepadStates[i] = GamePad.GetState(i);
            }
        }

        #region Keyboard
        public static bool IsKeyDown(Keys key)
        {
            return CurrentKeyboardState.IsKeyDown(key);
        }
        public static bool IsKeyUp(Keys key)
        {
            return CurrentKeyboardState.IsKeyUp(key);
        }

        public static bool WasKeyDown(Keys key)
        {
            return PreviouseKeyboardState.IsKeyDown(key);
        }
        public static bool WasKeyUp(Keys key)
        {
            return PreviouseKeyboardState.IsKeyUp(key);
        }

        public static bool IsKeyPressed(Keys key)
        {
            return IsKeyDown(key) && WasKeyUp(key);
        }
        public static bool IsKeyReleased(Keys key)
        {
            return IsKeyUp(key) && WasKeyDown(key);
        }
        #endregion

        #region Mouse
        public static void SetPointerPosition(int x, int y)
        {
            Mouse.SetPosition(x, y);
        }

        public static void ForcePointerPosition(int x, int y)
        {
            Mouse.SetPosition(x, y);
            //PreviouseMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
        }

        public static void SetPointerPosition(Point position)
        {
            SetPointerPosition(position.X, position.Y);
        }

        public static void ForcePointerPosition(Point position)
        {
            ForcePointerPosition(position.X, position.Y);
        }

        public static Point GetPointerPosition()
        {
            return CurrentMouseState.Position;
        }

        public static bool IsLeftButtonEqualTo(ButtonState state)
        {
            return CurrentMouseState.LeftButton == state;
        }

        public static bool IsRightButtonEqualTo(ButtonState state)
        {
            return CurrentMouseState.RightButton == state;
        }

        public static bool WasLeftButtonEqualTo(ButtonState state)
        {
            return PreviouseMouseState.LeftButton == state;
        }

        public static bool WasRightButtonEqualTo(ButtonState state)
        {
            return PreviouseMouseState.RightButton == state;
        }

        #endregion

        #region Gamepad

        #endregion

    }
}
