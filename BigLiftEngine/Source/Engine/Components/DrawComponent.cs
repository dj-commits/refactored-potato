using BigLiftEngine.Source.Engine.Animations;
using BigLiftEngine.Source.Engine.Entities;
using BigLiftEngine.Source.Engine.Systems;
using BigLiftEngine.Source.Engine.Utilities;
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
        public enum TextureType
        {
            None,
            Static,
            Animated,
            Tile
        }
        public TextureType EnumerableTextureType { get; set; }
        public Texture2D Texture { get; set; }
        public TileTexture TileTexture { get; set; }
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
            

            switch (EnumerableTextureType)
            {
                case TextureType.None:
                    RegisterSystem.DeregisterEntity(Entity.ID, Entity);

                    break;

                case TextureType.Static:
                    CurrentFrame = Texture;
                    RectangleFrame = new Rectangle(0, 0, Texture.Width, Texture.Height);

                    break;

                case TextureType.Animated:
                    Position = Entity.GetComponent<MoveComponent>().Position;
                    CurrentAnimation.frameTimeLeft -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (CurrentAnimation.frameTimeLeft <= 0)
                    {
                        CurrentAnimation.frameTimeLeft += CurrentAnimation.frameTime;
                        CurrentAnimation.frame = (CurrentAnimation.frame + 1) % CurrentAnimation.framesX;
                    }
                    CurrentFrame = CurrentAnimation.spriteSheet;
                    RectangleFrame = CurrentAnimation.sourceRectangles[CurrentAnimation.frame];

                    break;

                case TextureType.Tile:
                    CurrentFrame = TileTexture.TileSet;
                    RectangleFrame = TileTexture.TileFrame;
                    break;
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
