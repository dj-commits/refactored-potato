using BigLiftEngine.Source.Engine.Entities;
using BigLiftEngine.Source.Engine.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace BigLiftEngine.Source.Engine.Components
{
    public class CollisionComponent : Component
    {
        public Rectangle Collider { get; set; }

        public enum CollisionLayer
        {
            None,
            Projectile,
            Enemy,
            Player,
            StaticObjects
        }

        public CollisionLayer Layer { get; set; }

        public Entity[] LastCollision { get; set; }
        public bool Collided { get; set; }
        public bool horizontalCollision { get; set; }
        public bool verticalCollision { get; set; }

        public CollisionComponent(Entity entity) : base(entity)
        {
            Entity = entity;
        }
        public override void Update(GameTime gameTime)
        {
            Rectangle currentCollider = new Rectangle(0, 0, 0, 0);
            Rectangle newCollider = new Rectangle(0, 0, 0, 0);
            
            MoveComponent moveC = Entity.GetComponent<MoveComponent>();
            DrawComponent drawC = Entity.GetComponent<DrawComponent>();
            Vector2 response = new Vector2(moveC.Position.X, moveC.Position.Y);

            currentCollider.X = (int)moveC.Position.X;
            currentCollider.Y = (int)moveC.Position.Y;
            currentCollider.Width = drawC.RectangleFrame.Width;
            currentCollider.Height = drawC.RectangleFrame.Height;
            Collider = currentCollider;

            newCollider.X = (int)moveC.Position.X + (int)moveC.Direction.X;
            newCollider.Y = (int)moveC.Position.Y + (int)moveC.Direction.Y;
            newCollider.Width = drawC.RectangleFrame.Width;
            newCollider.Height = drawC.RectangleFrame.Height;

            foreach (CollisionComponent otherCollider in RegisterSystem.GetComponents<CollisionComponent>())
            {
                Collided = false;
                if(otherCollider.Entity.ID != Entity.ID)
                {
                    if(Layer != otherCollider.Layer)
                    {
                        if (newCollider.Intersects(otherCollider.Collider))
                        {
                            // if there is a horizontal collision
                            if (new Rectangle(newCollider.X + (int)moveC.Direction.X, newCollider.Y, newCollider.Width, newCollider.Height).Intersects(otherCollider.Collider))
                            {
                                horizontalCollision = true;
                                Collided = true;
                                // determine if it's left/right and respond
                                if (CollisionLeft(newCollider, otherCollider.Collider))
                                {
                                    response.X += Math.Sign(moveC.MovementDelta * 4);
                                }
                                else
                                {
                                    response.X -= Math.Sign(moveC.MovementDelta * 4);
                                }
                                // if there is a vertical collision
                                if (new Rectangle(newCollider.X, newCollider.Y + (int)moveC.Direction.Y, newCollider.Width, newCollider.Height).Intersects(otherCollider.Collider))
                                {
                                    verticalCollision = true;

                                    // determine if it's up/down and queue response
                                    if (CollisionUp(newCollider, otherCollider.Collider))
                                    {
                                        response.Y += Math.Sign(moveC.MovementDelta * 4);
                                    }
                                    else
                                    {
                                        response.Y -= Math.Sign(moveC.MovementDelta * 4);
                                    }
                                }
                            }
                            // check vertical collision if there is no horizontal
                            else if (new Rectangle(newCollider.X, newCollider.Y + (int)moveC.Direction.Y, newCollider.Width, newCollider.Height).Intersects(otherCollider.Collider))
                            {
                                verticalCollision = true;
                                Collided = true;
                                // determine if it's up/down and queue response
                                if (CollisionUp(newCollider, otherCollider.Collider))
                                {
                                    response.Y += Math.Sign(moveC.MovementDelta * 4);
                                }
                                else
                                {
                                    response.Y -= Math.Sign(moveC.MovementDelta * 4);
                                }
                            }
                            //else
                            //{
                            //    horizontalCollision = false;
                            //    verticalCollision = false;
                            //}

                            moveC.Position = response;

                        }
                    }
                    // if there is going to be a collision
                    
                    else
                    {
                        moveC.Position = response;
                        Collider = newCollider;

                    }

                    if (Collided)
                    {
                        if(LastCollision != null)
                        {
                            LastCollision[0] = otherCollider.Entity;
                        }
                        else
                        {
                            LastCollision = new Entity[1];
                        }

                    }
                }
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

        public bool CollisionLeft(Rectangle origin, Rectangle other)
        {
            if (origin.Center.X > other.Center.X)
            {
                return true;
            }
            return false;
        }

        public bool CollisionRight(Rectangle origin, Rectangle other)
        {
            if (origin.Center.X <= other.Center.X)
            {
                return true;
            }
            return false;
        }

        public bool CollisionUp(Rectangle origin, Rectangle other)
        {
            if (origin.Center.Y >= other.Center.Y)
            {
                return true;
            }
            return false;
        }

        public bool CollisionDown(Rectangle origin, Rectangle other)
        {
            if (origin.Center.Y <= other.Center.Y)
            {
                return true;
            }
            return false;
        }


    }
}
