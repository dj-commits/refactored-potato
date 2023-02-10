using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Growth.Source.Data;
using Growth.Source.Interfaces;
using Growth.Source.Entities;
using Growth.Source.Input;


namespace Growth.Source.Systems
{
    public class InputSystem : IUpdateDraw
    {
        public Player player;
        public PlayerMovement playerMovement;

        public InputSystem(Player player, bool controller)
        {
            this.player = player;
            playerMovement = new PlayerMovement();
        }
        public void Update(GameTime gameTime)
        {
            playerMovement.MoveUp(player);
            playerMovement.MoveDown(player);
            playerMovement.MoveLeft(player);
            playerMovement.MoveRight(player);
        }

        public void Draw(GameTime gameTime)
        {

        }
    }
}
