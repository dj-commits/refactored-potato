using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Source.Input
{
    public static class Input
    {
        public static KeyboardState KeyboardState { get; set; }
        public static MouseState MouseState { get; set; }

        public static void Update(GameTime gameTime)
        {
            KeyboardState = Keyboard.GetState();
            MouseState = Mouse.GetState();
        }
    }
}
