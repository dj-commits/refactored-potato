using BigLiftEngine.Source.Engine.Entities;
using BigLiftEngine.Source.Engine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BigLiftEngine.Source.Engine.Components
{
    public abstract class Component
    {
        public Entity Entity { get; set; }

        public Component(Entity entity)
        {
            Entity = entity;
            RegisterSystem.RegisterComponent(entity.ID, this);
            RegisterSystem.RegisterEntity(entity.ID, Entity);
        }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw();

        public abstract void ReceiveMessage(int message);
    }
}
