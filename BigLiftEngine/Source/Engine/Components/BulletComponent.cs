using BigLiftEngine.Source.Engine.Animations;
using BigLiftEngine.Source.Engine.Entities;
using BigLiftEngine.Source.Engine.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Components
{
    public class BulletComponent : Component
    {
        public int Damage { get; set; }

        public Animation ShotAnimation { get; set; }
        public Vector2 Velocity { get; set; }
        public float collisionBufferTime { get; set; }
        public float projectlieLifetime { get; set; }

        public BulletComponent(Entity entity) : base(entity)
        {
            Entity = entity;
            collisionBufferTime = .02f;
            projectlieLifetime = 2f;
            Damage = 75;
        }

        public override void Update(GameTime gameTime)
        {
            if(projectlieLifetime <= 0)
            {
                projectlieLifetime = 0;
                RegisterSystem.DeregisterEntity(Entity.ID, Entity);
            }
            else
            {
                if (collisionBufferTime <= 0)
                {
                    collisionBufferTime = 0;
                    if (Entity.GetComponent<CollisionComponent>() == null)
                    {
                        Entity.AddComponent(new CollisionComponent(Entity));
                        Entity.GetComponent<CollisionComponent>().Layer = CollisionComponent.CollisionLayer.Projectile;
                    }
                    CollisionComponent collisionC = Entity.GetComponent<CollisionComponent>();
                    if (collisionC.LastCollision != null)
                    {
                        if (collisionC.LastCollision[0] != null)
                        {
                            if (collisionC.LastCollision[0].GetComponent<PlayerComponent>() == null)
                            {
                                collisionC.LastCollision[0].GetComponent<HealthComponent>().TakeDamage(Damage);
                                RegisterSystem.DeregisterEntity(Entity.ID, Entity);
                            }
                            else
                            {
                                RegisterSystem.DeregisterEntity(Entity.ID, Entity);
                            }


                        }
                    }

                }
                else
                {
                    collisionBufferTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                }


                projectlieLifetime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            

        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void ReceiveMessage(int message)
        {
            throw new NotImplementedException();
        }


    }
}
