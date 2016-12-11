using OpenTK;
using OpenTK.Input;

using System;
using System.Collections.Generic;

namespace GlumEngine2D
{
    public class Input
    {
        // Key Lists
        private static readonly List<Key> currentKeys = new List<Key>();
        private static readonly List<Key> downKeys = new List<Key>();
        private static readonly List<Key> upKeys = new List<Key>();

        // Mouse Lists
        private static readonly List<MouseButton> currentMouseButtons = new List<MouseButton>();
        private static readonly List<MouseButton> downMouseButtons = new List<MouseButton>();
        private static readonly List<MouseButton> upMouseButtons = new List<MouseButton>();

        internal static void Update()
        {
            upKeys.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(Key)).Length; i++)
            {
                if (!GetKey((Key)i) && currentKeys.Contains((Key)i))
                {
                    upKeys.Add((Key)i);
                }
            }

            downKeys.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(Key)).Length; i++)
            {
                if (GetKey((Key)i) && !currentKeys.Contains((Key)i))
                {
                    downKeys.Add((Key)i);
                }
            }

            currentKeys.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(Key)).Length; i++)
            {
                if (GetKey((Key)i))
                {
                    currentKeys.Add((Key)i);
                }
            }

            upMouseButtons.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(MouseButton)).Length; i++)
            {
                if (!GetMouseButton((MouseButton)i) && currentMouseButtons.Contains((MouseButton)i))
                {
                    upMouseButtons.Add((MouseButton)i);
                }
            }

            downMouseButtons.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(MouseButton)).Length; i++)
            {
                if (GetMouseButton((MouseButton)i) && !currentMouseButtons.Contains((MouseButton)i))
                {
                    downMouseButtons.Add((MouseButton)i);
                }
            }

            currentMouseButtons.Clear();
            for (int i = 0; i < Enum.GetNames(typeof(MouseButton)).Length; i++)
            {
                if (GetMouseButton((MouseButton)i))
                {
                    currentMouseButtons.Add((MouseButton)i);
                }
            }
        }

        public static bool GetKey(Key keyCode)
        {
            // If we aren't focused then we can't be pressing anything!
            if (!Game.Instance.Focused)
            {
                return false;
            }
            // Get if the key 'keyCode' is down.
            return Keyboard.GetState().IsKeyDown((short)keyCode);
        }

        public static bool GetKeyDown(Key keyCode)
        {
            // If we aren't focused then we can't be pressing anything!
            if (!Game.Instance.Focused)
            {
                return false;
            }
            // Return whether our downkeys list contains the key 'keyCode' in a boolean format.
            return downKeys.Contains(keyCode);
        }

        public static bool GetKeyUp(Key keyCode)
        {
            // If we aren't focused then we can't be pressing anything!
            if (!Game.Instance.Focused)
            {
                return false;
            }
            // Return whether our upkeys list contains the key 'keyCode' in a boolean format.
            return upKeys.Contains(keyCode);
        }

        public static bool GetMouseButton(MouseButton mouseButton)
        {
            // If we aren't focused then we can't be clicking anything!
            if (!Game.Instance.Focused)
            {
                return false;
            }
            // Get if the mouse button 'mouseButton' is down.
            return Mouse.GetState().IsButtonDown(mouseButton);
        }

        public static bool GetMouseButtonDown(MouseButton mouseButton)
        {
            // If we aren't focused then we can't be clicking anything!
            if (!Game.Instance.Focused)
            {
                return false;
            }
            // Return whether our downkeys list contains the key 'keyCode' in a boolean format.
            return downMouseButtons.Contains(mouseButton);
        }

        public static bool GetMouseButtonUp(MouseButton mouseButton)
        {
            // If we aren't focused then we can't be clicking anything!
            if (!Game.Instance.Focused)
            {
                return false;
            }
            // Return whether our upkeys list contains the key 'keyCode' in a boolean format.
            return upMouseButtons.Contains(mouseButton);
        }

        public static Vector2 GetMousePosition()
        {
            // Return our mouse position in the form of a Vector2
            return new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }

        public static void SetMousePosition(Vector2 position)
        {
            Mouse.SetPosition(position.X, position.Y);
        }

        public static void SetMousePosition(float x, float y)
        {
            Mouse.SetPosition(x, y);
        }

        public static void ShowCursor(bool visibility)
        {
            Game.Instance.CursorVisible = visibility;
        }
    }
}
