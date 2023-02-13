using BigLiftEngine.Source.Engine.Animations;
using BigLiftEngine.Source.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Components
{
    public class DrawComponent : Component
    {
        public Texture2D Texture { get; set; }

        public Texture2D CurrentFrame { get; set; }

        public Animation CurrentAnimation { get; set; }
        public Animation IdleAnimation { get; set; }
        public Animation WalkAnimation { get; set; }
        public Animation RunAnimation { get; set; }

        public Animation AttackAnimation { get; set; }
        public Animation DieAnimation { get; set; }


        public Vector2 Position { get; set; }

        public Rectangle RectangleFrame { get; set; }

        public Vector2 Origin { get; set; }

        public Vector2 Scale { get; set; }

        public DrawComponent(Entity entity) : base(entity)
        {
            Entity = entity;
            Origin = new Vector2(0, 0);
            Scale = new Vector2(1, 1);
        }

        public override void Update(GameTime gameTime)
        {
            Position = Entity.GetComponent<MoveComponent>().Position;
            if(CurrentAnimation != null)
            {
                CurrentAnimation.frameTimeLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (CurrentAnimation.frameTimeLeft <= 0)
                {
                    CurrentAnimation.frameTimeLeft += CurrentAnimation.frameTime;
                    CurrentAnimation.frame = (CurrentAnimation.frame + 1) % CurrentAnimation.framesX;
                }
                CurrentFrame = CurrentAnimation.spriteSheet;
                RectangleFrame = CurrentAnimation.sourceRectangles[CurrentAnimation.frame];

            }
            else
            {
                CurrentFrame = Texture;
                RectangleFrame = new Rectangle(0, 0, Texture.Width, Texture.Height);
            }
        }

        public override void Draw()
        {
        }
        public override void ReceiveMessage(int message)
        {
            return;
        }
    }
}
