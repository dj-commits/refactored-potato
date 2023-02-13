using BigLiftEngine.Source.Engine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Components
{
    public class HealthComponent : Component
    {
        public int Health { get; set; }
        public double MaxHealth { get; set; }

        public HealthComponent(Entity entity) : base(entity)
        {
            Entity = entity;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw()
        {
            return;
        }

        public override void ReceiveMessage(int message)
        {
            return;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

       
    }
}
