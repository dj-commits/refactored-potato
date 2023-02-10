using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Growth.Source.Data;
using Growth.Source.Systems;
using Growth.Source.Animations;
using Growth.Source.Sprites;
using Growth.Source.UI;

namespace Growth.Source.Entities
{
    public class Player : Entity
    {
        

        public Player()
        {
            this.entityData = new EntityData();
            this.camera = new Camera(this);
            entityData.position = new Vector2(100, 100);
            entityData.speed = 300f;
            this.idleAnim = AnimationFactory.playerIdle;
            this.runAnim = AnimationFactory.playerRun;
            this.currentAnimation = idleAnim;
            this.sprite = new Sprite(idleAnim.spriteSheet, new Vector2(0, 0), new Vector2(1, 1));

        }

        public override void Move(GameTime gameTime)
        {
            if (movingUp)
            {
                entityData.position.Y -= entityData.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (movingDown)
            {
                entityData.position.Y += entityData.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (movingLeft)
            {
                entityData.position.X -= entityData.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (movingRight)
            {
                entityData.position.X += entityData.speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

    }
}
