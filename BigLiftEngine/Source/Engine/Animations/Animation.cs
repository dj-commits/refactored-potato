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
        public Texture2D spriteSheet;
        public Texture2D currentTextureFrame;
        public Rectangle[] sourceRectangles;
        public int frame;
        public int framesX;
        public int framesY;
        public int framesWidth;
        public int framesHeight;
        public float frameTime;
        public float frameTimeLeft;
        public Vector2 origin;
        public Vector2 scale;

        public Animation(Texture2D spriteSheet, int frame, int framesX, int framesY, float frameTime, DrawComponent drawC)
        {
            origin = new Vector2(0, 0);
            scale = new Vector2(1, 1);
            this.spriteSheet = spriteSheet;
            this.frame = frame;
            this.framesX = framesX;
            this.framesY = framesY;
            this.framesWidth = spriteSheet.Width / framesX;
            this.framesHeight = spriteSheet.Height / framesY;
            this.frameTime = frameTime;
            this.frameTimeLeft = frameTime;
            this.sourceRectangles = new Rectangle[framesX];

            for (int i = 0; i < framesX; i++)
            {
                sourceRectangles[i] = new Rectangle(i * framesWidth, 0, framesWidth, framesHeight);
            }

            if(drawC.CurrentAnimation == null)
            {
                drawC.CurrentAnimation = this;
            }

        }
    }
}
