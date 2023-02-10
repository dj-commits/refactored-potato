using Growth.Source.Entities;
using Microsoft.Xna.Framework.Input;
using System;

namespace Growth.Source.Input
{
    public class PlayerMovement : InputAction
    {

        /* This class serves to hold keybinds for player movement actions*/

        public void MoveUp(Player player)
        {
            player.movingUp = Input.KeyboardState.IsKeyDown(Keys.W);
        }
        public void MoveDown(Player player)
        {
            player.movingDown = Input.KeyboardState.IsKeyDown(Keys.S);
        }
        public void MoveLeft(Player player)
        {
            player.movingLeft = Input.KeyboardState.IsKeyDown(Keys.A);
        }
        public void MoveRight(Player player)
        {
            player.movingRight = Input.KeyboardState.IsKeyDown(Keys.D);
        }



    }
}
