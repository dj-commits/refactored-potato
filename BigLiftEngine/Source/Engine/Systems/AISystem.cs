using BigLiftEngine.Source.Engine.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Systems
{
    public class AISystem
    {
        public static void Update(GameTime gameTime)
        {
            foreach (BasicAIComponent basicAIC in RegisterSystem.GetComponents<BasicAIComponent>())
            {
                basicAIC.Update(gameTime);
            }
        }
    }
}
