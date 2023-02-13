

using BigLiftEngine.Source.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BigLiftEngine.Source.Engine.Systems
{
    public static class InputSystem
    {
        public static void Update(GameTime gameTime)
        {
            foreach (InputComponent inputC in RegisterSystem.GetComponents<InputComponent>())
            {
                inputC.Update(gameTime);
            }
        }
    }
}
