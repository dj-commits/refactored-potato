
using BigLiftEngine.Source.Engine.Entities;
using Microsoft.Xna.Framework;


namespace BigLiftEngine.Source.Engine.Components
{
    public class CameraComponent : Component
    {
        public float Zoom { get; set; }
        public bool Active { get; set; }
        public Matrix Transform { get; private set; }

        public CameraComponent(Entity entity) : base(entity)
        {
            Entity = entity;
        }
        public override void Update(GameTime gameTime)
        {
            MoveComponent moveC = Entity.GetComponent<MoveComponent>();
            CollisionComponent collisionC = Entity.GetComponent<CollisionComponent>();
            Matrix position = Matrix.CreateTranslation(
              -moveC.Position.X - (collisionC.Collider.Width / 2),
              -moveC.Position.Y - (collisionC.Collider.Height / 2),
              0);


            Matrix offset = Matrix.CreateTranslation(
                1920 / 2,
                1080 / 2,
                0);

            //Transform = position * offset * Matrix.CreateScale(cameraZoom, cameraZoom, 0);
            Transform = position * Matrix.CreateScale(Zoom, Zoom, Zoom) * offset;


            //Console.WriteLine(Transform.ToString());
        }
        public override void Draw()
        {
            throw new System.NotImplementedException();
        }

        public override void ReceiveMessage(int message)
        {
            throw new System.NotImplementedException();
        }

        
    }
}

