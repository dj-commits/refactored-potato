using BigLiftEngine.Source.Engine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Components
{
    public class PlayerComponent : Component
    {

        public PlayerComponent(Entity entity) : base(entity)
        {
            Entity = entity;
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void ReceiveMessage(int message)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
