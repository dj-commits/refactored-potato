using BigLiftEngine.Source.Engine.Entities;
using BigLiftEngine.Source.Engine.Systems;
using BigLiftEngine.Source.Engine.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Components
{
    public class BasicAIComponent : Component
    {

        public enum State
        {
            Idle,
            Walk,
            Run,
            Attack,
            Die
        }

        public float DeathTimer { get; set; }


        public State state { get; set; }

        public float TargetRange { get; set; }

        public BasicAIComponent(Entity entity) : base(entity)
        {
            Entity = entity;
            this.state = State.Idle;
        }

        public override void Update(GameTime gameTime)
        {
           
            DrawComponent drawC = Entity.GetComponent<DrawComponent>();
            MoveComponent moveC = Entity.GetComponent<MoveComponent>();
            HealthComponent healthC = Entity.GetComponent<HealthComponent>();

            switch (state)
            {
                case State.Idle:
                    drawC.CurrentAnimation = drawC.IdleAnimation;
                    moveC.Target = Vector2.Zero;
                    moveC.Direction = Vector2.Zero;
                    TargetPlayer(moveC);
                    CheckHealth(healthC, moveC);
                    break;
                case State.Walk:
                    drawC.CurrentAnimation = drawC.WalkAnimation;
                    TargetPlayer(moveC);
                    CheckHealth(healthC, moveC);
                    break;
                case State.Run:
                    drawC.CurrentAnimation = drawC.RunAnimation;
                    CheckHealth(healthC, moveC);
                    Flee(moveC, GetClosestPlayer(moveC));
                    break;
                case State.Attack:
                    drawC.CurrentAnimation = drawC.AttackAnimation;
                    break;
                case State.Die:
                    drawC.CurrentAnimation = drawC.DieAnimation;
                    moveC.Speed = 0f;
                    if(DeathTimer <= 0)
                    {
                        DeathTimer = 0;
                        RegisterSystem.DeregisterEntity(Entity.ID, Entity);
                    }
                    else
                    {
                        DeathTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    break;

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

        public Entity GetClosestPlayer(MoveComponent moveC)
        {

            Entity closestPlayer = null;
            float furthest;
            float closest = 0f;

            // get up to date list of players
            List<Entity> players = new List<Entity>();
            foreach (PlayerComponent playerC in RegisterSystem.GetComponents<PlayerComponent>())
            {
                players.Add(playerC.Entity);
            }

            // loop through all players, finding the closest one
            for (int i = 0; i < players.Count; i++)
            {
                if (Util.GetDistance(moveC.Position, players[i].GetComponent<MoveComponent>().Position) < TargetRange)
                {
                    furthest = Util.GetDistance(moveC.Position, players[i].GetComponent<MoveComponent>().Position);
                    if (furthest > closest)
                    {
                        closest = furthest;
                        closestPlayer = players[i];
                    }
                }
            }
            return closestPlayer;
        }

        public void CheckHealth(HealthComponent healthC, MoveComponent moveC)
        {
            if(state != State.Run && healthC.Health < (healthC.MaxHealth * .80))
            {
                moveC.Target = Vector2.Zero;
                state = State.Run;
            }
            if (healthC.Health <= 0)
            {
                healthC.Health = 0;
                state = State.Die;
            }
        }

        public void Flee(MoveComponent moveC, Entity target)
        {
            
            if(target != null)
            {
                moveC.Direction = moveC.Position - target.GetComponent<MoveComponent>().Position;
                moveC.Direction = Vector2.Normalize(moveC.Direction);
                moveC.Direction *= moveC.MovementDelta;
                if(moveC.Target == Vector2.Zero)
                {
                    moveC.Target = -target.GetComponent<MoveComponent>().Position;
                }
            }
            

            if (Util.GetDistance(moveC.Target, moveC.Position) < 500f)
            {
                state = State.Idle;
            }



        }
        public void TargetPlayer(MoveComponent moveC)
        {

            Entity closestPlayer = GetClosestPlayer(moveC);

            if (closestPlayer != null)
            {
                moveC.Target = closestPlayer.GetComponent<MoveComponent>().Position;
                state = State.Walk;

            }
            else
            {
                state = State.Idle;

            }
        }
    }
}
