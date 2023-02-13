

using BigLiftEngine.Source.Engine.Components;
using Microsoft.Xna.Framework;

namespace BigLiftEngine.Source.Engine.Systems
{
    public class PhysicsSystem
    {
        public static void Update(GameTime gameTime)
        {
            foreach (CollisionComponent collisionC in RegisterSystem.GetComponents<CollisionComponent>())
            {
                collisionC.Update(gameTime);
            }
        }
    }
}
