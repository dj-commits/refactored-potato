

using BigLiftEngine.Source.Engine.Components;
using Microsoft.Xna.Framework;

namespace BigLiftEngine.Source.Engine.Systems
{
    public static class TileSystem
    {
        public static void Update(GameTime gameTime)
        {
            foreach (TileComponent tileC in RegisterSystem.GetComponents<TileComponent>())
            {
                tileC.Update(gameTime);
            }
        }
    }
}
