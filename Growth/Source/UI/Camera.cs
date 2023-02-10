using Growth.Source.Config;
using Growth.Source.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Growth.Source.UI
{
    public class Camera
    {
        public float cameraZoom = 2f;
        public bool isActive;
        public Entity target;
        public Matrix Transform { get; private set; }

        public Camera()
        {
            Transform = Matrix.Identity;
            isActive = false;
        }
        public Camera(Entity target)
        {
            this.target = target;
            isActive = false;
        }
        public void Follow(Entity target)
        {
            Matrix position = Matrix.CreateTranslation(
              -target.entityData.position.X - (target.currentAnimation.sourceRectangles[target.currentAnimation.frame].Width / 2),
              -target.entityData.position.Y - (target.currentAnimation.sourceRectangles[target.currentAnimation.frame].Height / 2),
              0);


            Matrix offset = Matrix.CreateTranslation(
                InitConfig.screenWidth / 2,
                InitConfig.screenWidth / 2,
                0);

            //Transform = position * offset * Matrix.CreateScale(cameraZoom, cameraZoom, 0);
            Transform = position * Matrix.CreateScale(cameraZoom, cameraZoom, cameraZoom) * offset;


            //Console.WriteLine(Transform.ToString());
        }

    }
}
