using BigLiftEngine.Source.Engine.Entities;
using BigLiftEngine.Source.Engine.Factories;
using BigLiftEngine.Source.Engine.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BigLiftEngine.Source.Engine.Scenes
{
    public class SceneManager
    {
        public Scene currentScene;
        public Scene previousScene;
        public Scene nextScene;
        public Scene mainMenuScene;
        public Scene gameScene;
        public Scene cutScene;
        public Scene gameOverScene;
        public Scene victoryScene;



        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public SceneManager(Game1 game, GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            _graphics = graphics;
            _spriteBatch = spriteBatch;
            _spriteBatch = new SpriteBatch(game.GraphicsDevice);
            Assets.LoadAllAssets(game.Content);
        }
        public void Initialize()
        {
            
            mainMenuScene = new Scene("Main Menu");
            gameScene = new Scene("Game");
            cutScene = new Scene("Cutscene");
            gameOverScene = new Scene("Game Over");
            victoryScene = new Scene("Victory");

            this.currentScene = gameScene;
        }

        public void LoadContent()
        {
            switch (currentScene.Name)
            {
                case "Main Menu":
                    ChangeScene(gameScene);
                    break;
                case "Game":
                    Factory.CreatePlayer("Player");
                    Factory.CreateAlly("Baby");
                    Factory.CreateSpectre();
                    Factory.CreateSpectre();
                    Factory.CreateSpectre();
                    Factory.CreateSpectre();
                    Factory.CreateSpectre();
                    Factory.CreateSpectre();
                    Factory.CreateSpectre();
                    Factory.CreateSpectre();
                    Factory.CreateSpectre();
                    Factory.CreateSpectre();
                    Factory.CreateSpectre();
                    Factory.CreateSpectre();

                    Factory.CreateSpectre();


                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            currentScene.Draw(_spriteBatch);
        }

        public void RegisterEntityInScene(Entity entity)
        {
            this.currentScene.currentEntities.Add(entity);
        }

        public void ChangeScene(Scene scene)
        {
            previousScene = currentScene;
            currentScene = scene;
        }
    }
}
