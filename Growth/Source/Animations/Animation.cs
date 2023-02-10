using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Growth.Source.Animations
{
    public class Animation
    {
        public Texture2D spriteSheet;
        public Texture2D currentTextureFrame;
        public Texture2D defaultTextureFrame;
        public Rectangle[] sourceRectangles;
        public int frame;
        public int framesX;
        public int framesY;
        public int framesWidth;
        public int framesHeight;
        public float frameTime;
        public float frameTimeLeft;



        public Animation(Texture2D spriteSheet, int frame, int framesX, int framesY, float frameTime)
        {
            this.spriteSheet = spriteSheet;
            this.frame = frame;
            this.framesX = framesX;
            this.framesY = framesY;
            framesWidth = spriteSheet.Width / framesX;
            framesHeight = spriteSheet.Height / framesY;
            this.frameTime = frameTime;
            frameTimeLeft = frameTime;
            sourceRectangles = new Rectangle[framesX];

            for (int i = 0; i < framesX; i++)
            {
                sourceRectangles[i] = new Rectangle(i * framesWidth, 0, framesWidth, framesHeight);
            }

        }

        
    }
}

