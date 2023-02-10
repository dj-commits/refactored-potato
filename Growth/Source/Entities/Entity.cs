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
    public class Entity
    {
        public EntityData entityData;

        public Sprite sprite;

        public float frameTime;
        public bool movingUp;
        public bool movingDown;
        public bool movingLeft;
        public bool movingRight;

        public Animation idleAnim;
        public Animation walkAnimation;
        public Animation runAnim;
        public Animation dieAnimation;
        public Animation currentAnimation;

        public Camera camera;

        public Entity()
        {
        }


        public virtual void Update(GameTime gameTime)
        {
            if(camera.isActive == true)
            {
                camera.Follow(this);
            }
            if (currentAnimation != null)
            {
                Animate(gameTime);
            }
            Move(gameTime);

        }
        public virtual void Move(GameTime gameTime)
        {

        }

        public virtual void Animate(GameTime gameTime)
        {
            currentAnimation.frameTimeLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (currentAnimation.frameTimeLeft <= 0)
            {
                currentAnimation.frameTimeLeft += currentAnimation.frameTime;
                currentAnimation.frame = (currentAnimation.frame + 1) % currentAnimation.framesX;
            }
        }
    }
}
