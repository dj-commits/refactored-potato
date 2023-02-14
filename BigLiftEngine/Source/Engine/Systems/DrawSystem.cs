using BigLiftEngine.Source.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Systems
{
    public static class DrawSystem
    {
        public static Matrix activeCamera;
        public static void Update(GameTime gameTime)
        {
            foreach (DrawComponent drawC in RegisterSystem.GetComponents<DrawComponent>())
            {
                drawC.Update(gameTime);
            }
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, null, SamplerState.PointClamp, transformMatrix: activeCamera);
            foreach (DrawComponent drawC in RegisterSystem.GetComponents<DrawComponent>())
            {
                spriteBatch.Draw(
                    texture: drawC.CurrentFrame,
                    position: drawC.Position,
                    sourceRectangle: drawC.RectangleFrame,
                    color: Color.White,
                    rotation: 0f,
                    origin: drawC.Origin,
                    scale: drawC.Scale,
                    effects: SpriteEffects.None,
                    layerDepth: drawC.LayerDepth);
            }
            spriteBatch.End();

            
            
            

        }

        public static void SetActiveCamera(Matrix transform)
        {
            activeCamera = transform;
        }
    }
}
