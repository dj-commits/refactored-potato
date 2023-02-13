using BigLiftEngine.Source.Engine.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Systems
{
    public class BulletSystem
    {
        public static void Update(GameTime gameTime)
        {
            foreach (BulletComponent bulletC in RegisterSystem.GetComponents<BulletComponent>())
            {
                bulletC.Update(gameTime);
            }
        }
    }
}
