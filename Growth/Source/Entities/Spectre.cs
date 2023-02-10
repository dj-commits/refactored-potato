

using Growth.Source.Animations;
using Growth.Source.Data;
using Growth.Source.Sprites;
using Growth.Source.UI;
using Microsoft.Xna.Framework;

namespace Growth.Source.Entities
{
    public class Spectre : Entity
    {


        public Spectre()
        {
            this.entityData = new EntityData();
            this.camera = new Camera(this);
            entityData.position = new Vector2(400, 400);
            entityData.speed = 300f;
            this.idleAnim = AnimationFactory.spectreIdle;
            this.runAnim = AnimationFactory.spectreRun;
            this.currentAnimation = idleAnim;
            this.sprite = new Sprite(idleAnim.spriteSheet, new Vector2(0, 0), new Vector2(1, 1));
        }

        public Spectre(Vector2 position)
        {
            this.entityData = new EntityData();
            this.camera = new Camera(this);
            entityData.position = position;
            entityData.speed = 300f;
            this.idleAnim = AnimationFactory.spectreIdle;
            this.runAnim = AnimationFactory.spectreRun;
            this.currentAnimation = idleAnim;
            this.sprite = new Sprite(idleAnim.spriteSheet, new Vector2(0, 0), new Vector2(1, 1));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Move(GameTime gameTime)
        {
            base.Move(gameTime);
        }

        public override void Animate(GameTime gameTime)
        {
            base.Animate(gameTime);
        }
    }
}
