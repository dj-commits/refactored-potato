

using BigLiftEngine.Source.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace BigLiftEngine.Source.Engine.Systems
{
    public static class InputSystem
    {
        public static void Update(GameTime gameTime)
        {
            foreach (InputComponent inputC in RegisterSystem.GetComponents<InputComponent>())
            {
                inputC.Update(gameTime);
                Console.WriteLine($"Current Entity Count: {RegisterSystem.registeredEntities.Count}");
                Console.WriteLine($"Current Tile Count: {RegisterSystem.GetComponents<TileComponent>().Count}");
            }
        }
    }
}
