using BigLiftEngine.Source.Engine.Animations;
using BigLiftEngine.Source.Engine.Entities;
using BigLiftEngine.Source.Engine.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Components
{
    public class TileComponent : Component
    {
        public bool Collideable { get; set; }


        public Vector2Int Position { get; set; }

        public TileComponent(Entity entity) : base(entity)
        {
            Entity = entity;
        }

        public override void Draw()
        {
            return;
        }

        public override void ReceiveMessage(int message)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {

        }


    }
}
