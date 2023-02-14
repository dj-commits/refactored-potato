using BigLiftEngine.Source.Engine.Components;
using BigLiftEngine.Source.Engine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Animations
{
    public class Animation
    {
        public Texture2D SpriteSheet { get; set; }
        public Texture2D CurrentTextureFrameX { get; set; }
        public Texture2D CurrentTextureFrameY { get; set; }
        public Rectangle[] SourceRectangles { get; set; }
        public int Frame { get; set; }
        public int FramesX { get; set; }
        public int FramesY { get; set; }
        public int FramesWidth { get; set; }
        public int FramesHeight { get; set; }
        public float FrameTime { get; set; }
        public float FrameTimeLeft { get; set; }
        public Vector2 Origin { get; set; }
        public Vector2 Scale { get; set; }
        public float LayerDepth { get; set; }

        public Animation(Texture2D spriteSheet, int frame, int framesX, int framesY, float frameTime, float layerDepth, DrawComponent drawC)
        {
            Origin = new Vector2(0, 0);
            Scale = new Vector2(1, 1);
            this.SpriteSheet = spriteSheet;
            this.Frame = frame;
            this.FramesX = framesX;
            this.FramesY = framesY;
            this.FramesWidth = spriteSheet.Width / framesX;
            this.FramesHeight = spriteSheet.Height / framesY;
            this.FrameTime = frameTime;
            this.FrameTimeLeft = frameTime;
            this.SourceRectangles = new Rectangle[framesX];
            this.LayerDepth = layerDepth;

            for (int i = 0; i < framesX; i++)
            {

                    SourceRectangles[i] = new Rectangle(i * FramesWidth, 0, FramesWidth, FramesHeight);

            }

            if (drawC.CurrentAnimation == null)
            {
                drawC.CurrentAnimation = this;
            }

        }
    }
}
