using BigLiftEngine.Source.Engine.Animations;
using BigLiftEngine.Source.Engine.Components;
using BigLiftEngine.Source.Engine.Entities;
using BigLiftEngine.Source.Engine.Utilities;
using Microsoft.Xna.Framework;
using System;

namespace BigLiftEngine.Source.Engine.Factories
{
    public static class Factory
    {
        public static Entity CreatePlayer(string name)
        {
            Entity player = new Entity(name);

            player.AddComponent(new InputComponent(player));
            player.AddComponent(new MoveComponent(player));
            player.AddComponent(new DrawComponent(player));
            player.AddComponent(new PlayerComponent(player));
            player.AddComponent(new CollisionComponent(player));

            DrawComponent drawC = player.GetComponent<DrawComponent>();
            MoveComponent moveC = player.GetComponent<MoveComponent>();
            CollisionComponent collisionC = player.GetComponent<CollisionComponent>();

            drawC.Texture = Assets.Texture(@"Textures/malezomb");
            drawC.IdleAnimation = new Animation(Assets.Texture(@"Textures/DuckRun"), 0, 8, 1, .3f, drawC);
            drawC.WalkAnimation = new Animation(Assets.Texture(@"Textures/DuckRun"), 0, 8, 1, .1f, drawC);
            drawC.RunAnimation = new Animation(Assets.Texture(@"Textures/DuckRun"), 0, 8, 1, .05f, drawC);
            drawC.AttackAnimation = new Animation(Assets.Texture(@"Textures/DuckRun"), 0, 8, 1, .01f, drawC);
            drawC.DieAnimation = new Animation(Assets.Texture(@"Textures/DuckRun"), 0, 8, 1, 1f, drawC);

            moveC.Position = new Vector2(100, 100);
            moveC.Speed = 300f;

            collisionC.Layer = CollisionComponent.CollisionLayer.Player;


            return player;
        }

        public static Entity CreateAlly(string name)
        {
            Entity ally = new Entity(name);

            ally.AddComponent(new MoveComponent(ally));
            ally.AddComponent(new DrawComponent(ally));
            ally.AddComponent(new PlayerComponent(ally));
            ally.AddComponent(new CollisionComponent(ally));

            DrawComponent drawC = ally.GetComponent<DrawComponent>();
            MoveComponent moveC = ally.GetComponent<MoveComponent>();
            CollisionComponent collisionC = ally.GetComponent<CollisionComponent>();

            drawC.Texture = Assets.Texture(@"Textures/malezomb");
            drawC.IdleAnimation = new Animation(Assets.Texture(@"Textures/baby"), 0, 8, 1, .3f, drawC);
            drawC.WalkAnimation = new Animation(Assets.Texture(@"Textures/baby"), 0, 8, 1, .1f, drawC);
            drawC.RunAnimation = new Animation(Assets.Texture(@"Textures/baby"), 0, 8, 1, .05f, drawC);
            drawC.AttackAnimation = new Animation(Assets.Texture(@"Textures/baby"), 0, 8, 1, .01f, drawC);
            drawC.DieAnimation = new Animation(Assets.Texture(@"Textures/baby"), 0, 8, 1, 1f, drawC);

            collisionC.Layer = CollisionComponent.CollisionLayer.Player;


            moveC.Position = new Vector2(100, 100);
            moveC.Speed = 0f;


            return ally;
        }

        public static Entity CreateSpectre()
        {
            Random random = new Random();
            Entity spectre = new Entity("Spectre");
            spectre.AddComponent(new MoveComponent(spectre));
            spectre.AddComponent(new DrawComponent(spectre));
            spectre.AddComponent(new BasicAIComponent(spectre));
            spectre.AddComponent(new HealthComponent(spectre));
            spectre.AddComponent(new CollisionComponent(spectre));


            DrawComponent drawC = spectre.GetComponent<DrawComponent>();
            MoveComponent moveC = spectre.GetComponent<MoveComponent>();
            CollisionComponent collisionC = spectre.GetComponent<CollisionComponent>();
            HealthComponent healthC = spectre.GetComponent<HealthComponent>();
            BasicAIComponent basicAIC = spectre.GetComponent<BasicAIComponent>();

            drawC.Texture = Assets.Texture(@"Textures/spectre");
            drawC.IdleAnimation = new Animation(Assets.Texture(@"Textures/spectre"), 0, 8, 1, .3f, drawC);
            drawC.WalkAnimation = new Animation(Assets.Texture(@"Textures/slither"), 0, 8, 1, .1f, drawC);
            drawC.RunAnimation = new Animation(Assets.Texture(@"Textures/glutton"), 0, 8, 1, .05f, drawC);
            drawC.AttackAnimation = new Animation(Assets.Texture(@"Textures/lou"), 0, 8, 1, .01f, drawC);
            drawC.DieAnimation = new Animation(Assets.Texture(@"Textures/spectre"), 0, 8, 1, 1f, drawC);

            moveC.Position = new Vector2(random.Next(0, 1000), random.Next(0, 800));
            moveC.Speed = 250f;

            collisionC.Layer = CollisionComponent.CollisionLayer.Enemy;

            healthC.Health = 100;
            healthC.MaxHealth = 100;

            basicAIC.TargetRange = 350f;
            basicAIC.DeathTimer = .6f;

            return spectre;
        }

        public static Entity CreateBullet()
        {
            Entity bullet = new Entity("Bill");
            bullet.AddComponent(new MoveComponent(bullet));
            bullet.AddComponent(new DrawComponent(bullet));
            bullet.AddComponent(new BulletComponent(bullet));

            MoveComponent moveC = bullet.GetComponent<MoveComponent>();
            DrawComponent drawC = bullet.GetComponent<DrawComponent>();
            BulletComponent bulletC = bullet.GetComponent<BulletComponent>();



            drawC.Texture = Assets.Texture(@"Textures/fireball");
            bulletC.ShotAnimation = new Animation(Assets.Texture(@"Textures/fireball"), 0, 8, 1, .1f, drawC);






            return bullet;
        }
    }
}
