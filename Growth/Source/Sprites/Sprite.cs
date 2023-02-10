using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Growth.Source.Sprites
{
    public class Sprite
    {
        public Texture2D currentSprite;
        public Vector2 origin;
        public Vector2 scale;

        public Sprite(Texture2D currentSprite, Vector2 origin, Vector2 scale)
        {
            this.currentSprite = currentSprite;
            this.origin = origin;
            this.scale = scale;
        }

    }
}
