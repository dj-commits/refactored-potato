using BigLiftEngine.Source.Engine.Entities;
using BigLiftEngine.Source.Engine.Systems;
using BigLiftEngine.Source.Engine.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BigLiftEngine.Source.Engine.Components
{
    public class MoveComponent : Component
    {
        public Vector2 Position { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }
        public Vector2 Target { get; set; }

        public float MovementDelta { get; set; }
        public bool CanMove { get; set; }

        public MoveComponent(Entity entity) : base(entity)
        {
            Entity = entity;
            CanMove = true;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 newDirection = new Vector2(0, 0);
            Vector2 newPosition = Position;
            float movementAmount = Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            MovementDelta = movementAmount;
            if (CanMove)
            {
                // If no InputComponent, assume AI
                if (Entity.GetComponent<InputComponent>() == null)
                {
                    if(Entity.GetComponent<BasicAIComponent>() != null)
                    {
                        if(Entity.GetComponent<BasicAIComponent>().state != BasicAIComponent.State.Run && Entity.GetComponent<BasicAIComponent>().state != BasicAIComponent.State.Idle)
                        {
                            Direction = Target - Position;
                            Direction = Vector2.Normalize(Direction);
                            Direction *= movementAmount;
                        }
                    }
                    // If no AI controller, assume projectile
                    else if(Entity.GetComponent<BulletComponent>() != null)
                    {
                        BulletComponent bulletC = Entity.GetComponent<BulletComponent>();
                        Direction = bulletC.Velocity;
                        Direction = Vector2.Normalize(Direction);
                        Direction *= MovementDelta;
                    }
                }
                else
                {
                    InputComponent inputC = Entity.GetComponent<InputComponent>();
                    if (inputC.keyboardState.IsKeyDown(Keys.W))
                    {
                        Entity.GetComponent<DrawComponent>().CurrentAnimation = Entity.GetComponent<DrawComponent>().WalkAnimation;
                        newDirection.Y -= movementAmount;
                    }
                    if (inputC.keyboardState.IsKeyDown(Keys.S))
                    {
                        Entity.GetComponent<DrawComponent>().CurrentAnimation = Entity.GetComponent<DrawComponent>().WalkAnimation;
                        newDirection.Y += movementAmount;
                    }
                    if (inputC.keyboardState.IsKeyDown(Keys.A))
                    {
                        Entity.GetComponent<DrawComponent>().CurrentAnimation = Entity.GetComponent<DrawComponent>().WalkAnimation;
                        newDirection.X -= movementAmount;
                    }
                    if (inputC.keyboardState.IsKeyDown(Keys.D))
                    {
                        Entity.GetComponent<DrawComponent>().CurrentAnimation = Entity.GetComponent<DrawComponent>().WalkAnimation;
                        newDirection.X += movementAmount;
                    }
                    Direction = newDirection;
                }


                newPosition.X += Direction.X;


                newPosition.Y += Direction.Y;


                Position = newPosition;
            }
        }

        public override void Draw()
        {
            return;
        }
        public override void ReceiveMessage(int message)
        {
            return;
        }
    }
}
