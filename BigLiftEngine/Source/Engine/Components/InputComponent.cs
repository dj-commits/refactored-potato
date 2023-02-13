using BigLiftEngine.Source.Engine.Entities;
using BigLiftEngine.Source.Engine.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BigLiftEngine.Source.Engine.Components
{
    public class InputComponent : Component    
    {
        public KeyboardState keyboardState;
        public MouseState mouseState;
        public InputComponent(Entity entity) : base(entity)
        {
            Entity = entity; 
        }

        public override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            if(mouseState.LeftButton == ButtonState.Pressed)
            {
                Vector2 mousePos = new Vector2(mouseState.Position.X, mouseState.Position.Y);
                ShootBullet(Entity.GetComponent<MoveComponent>().Position, mousePos);
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

        public void ShootBullet(Vector2 origin, Vector2 target)
        {
            Entity bullet = Factory.CreateBullet();
            MoveComponent moveC = bullet.GetComponent<MoveComponent>();
            BulletComponent bulletC = bullet.GetComponent<BulletComponent>();

            moveC.Position = origin;
            moveC.Target = target;
            moveC.Speed = 1000f;

            bulletC.Velocity = target - origin;
        }
       
    }
}
