using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Growth.Source.Scenes;
using Growth.Source.Data;
using Microsoft.Xna.Framework.Content;
using Growth.Source.Config;

namespace Growth
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SceneManager sceneManager;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = InitConfig.screenWidth;
            _graphics.PreferredBackBufferHeight = InitConfig.screenHeight;
            _graphics.ApplyChanges();
            sceneManager = new SceneManager();
            sceneManager.Initialize(this.Content, this.GraphicsDevice);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {

            sceneManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            sceneManager.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}