using Growth.Source.Entities;
using Growth.Source.Interfaces;
using Growth.Source.Systems;
using Growth.Source.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Growth.Source.UI;

namespace Growth.Source.Scenes
{
    public class Scene : IUpdateDraw
    {
        public List<Entity> entities;
        public string name;
        public Camera currentCamera;

        public Scene(string name)
        {
            this.name = name;
            this.entities = new List<Entity>();
        }

        public void LoadContent(string name)
        {
            switch (name)
            {
                case "playground":
                    Spectre spectre = new Spectre(new Vector2(200, 200));
                    Spectre spectre2 = new Spectre(new Vector2(300, 300));

                    entities.Add(spectre);
                    entities.Add(spectre2);
                    break;
                case "sandbox":
                    break;
            }
                
        }

        public void Update(GameTime gameTime)
        {

            foreach(Entity entity in entities)
            {
                if(entity.camera.isActive == true)
                {
                    currentCamera = entity.camera;
                }
                else
                {
                    currentCamera = null;
                }
                entity.Update(gameTime);
                
            }
        }

        public void Draw(GameTime gameTime)
        {
            if(currentCamera != null)
            {
                SceneManager.currentSpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, transformMatrix: currentCamera.Transform);
            }
            else
            {
                SceneManager.currentSpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            }

            foreach (Entity entity in entities)
            {
                SceneManager.currentSpriteBatch.Draw(
                 texture: entity.sprite.currentSprite,
                 position: entity.entityData.position,
                 sourceRectangle: entity.currentAnimation.sourceRectangles[entity.currentAnimation.frame],
                 color: Color.White,
                 rotation: 0f,
                 origin: entity.sprite.origin,
                 scale: entity.sprite.scale,
                 effects: SpriteEffects.None,
                 layerDepth: 0.1f);
            }
            SceneManager.currentSpriteBatch.End();

            //SceneManager.uiSpriteBatch.Begin();
            //SceneManager.uiSpriteBatch.End();
        }


    }
}
