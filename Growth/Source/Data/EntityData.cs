

using Microsoft.Xna.Framework;

namespace Growth.Source.Data
{
    public class EntityData
    {
        public Vector2 position;

        public Rectangle collider;

        public float speed;

        public float speedMultiplier;

        public Vector2 GetPosition()
        {
            return this.position;
        }
    }
}
