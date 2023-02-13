using BigLiftEngine.Source.Engine.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Systems
{
    public static class MoveSystem
    {
        public static void Update(GameTime gameTime)
        {
            foreach (MoveComponent moveC in RegisterSystem.GetComponents<MoveComponent>())
            {
                moveC.Update(gameTime);
            }
        }
    }
}
