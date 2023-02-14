using BigLiftEngine.Source.Engine.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Systems
{
    public static class CameraSystem
    {
        public static void Update(GameTime gameTime)
        {
            foreach (CameraComponent cameraC in RegisterSystem.GetComponents<CameraComponent>())
            {
                if (cameraC.Active)
                {
                    DrawSystem.SetActiveCamera(cameraC.Transform);
                    cameraC.Update(gameTime);
                }

            }
        }
    }
}
