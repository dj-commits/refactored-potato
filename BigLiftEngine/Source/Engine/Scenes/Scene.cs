using BigLiftEngine.Source.Engine.Entities;
using BigLiftEngine.Source.Engine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace BigLiftEngine.Source.Engine.Scenes
{
    public class Scene
    {
        public List<Entity> currentEntities;
        public string Name { get; set; }

        public Scene(string name)
        {
            Name = name;
            currentEntities = new List<Entity>(); 
        }

        public void Update(GameTime gameTime)
        {
            InputSystem.Update(gameTime);
            MoveSystem.Update(gameTime);
            DrawSystem.Update(gameTime);
            BulletSystem.Update(gameTime);
            PhysicsSystem.Update(gameTime);
            AISystem.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawSystem.Draw(spriteBatch);
        }

    }
}
