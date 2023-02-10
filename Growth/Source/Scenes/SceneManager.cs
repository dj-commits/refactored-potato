using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Growth.Source.Interfaces;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Growth.Source.Data;
using Growth.Source.Entities;
using Growth.Source.Input;
using Growth.Source.Systems;
using Growth.Source.UI;

namespace Growth.Source.Scenes
{
    public class SceneManager    {
        /* Main game manager class, handles game state and the transition between them */
        public static Game1 game;
        public static Scene activeScene;
        public static Scene previousScene;
        public static Scene nextScene;

        public Scene playGroundScene;
        public Scene sandboxScene;

        public static Player player;

        public static ContentManager currentContent;
        public static ContentManager persistentContent;
        public static SpriteBatch currentSpriteBatch;
        public static SpriteBatch uiSpriteBatch;

        public InputSystem inputSystem;


        public void Initialize(ContentManager content, GraphicsDevice graphicsDevice)
        {
            persistentContent = content;
            currentContent = content;
            Assets.LoadAllAssets(persistentContent);
            currentSpriteBatch = new SpriteBatch(graphicsDevice);
            playGroundScene = new Scene("playground");
            sandboxScene = new Scene("sandbox");
            ChangeScene(playGroundScene);

            player = new Player();
            activeScene.entities.Add(player);
            inputSystem = new InputSystem(player, false);
            player.camera.isActive = true;
        }


        public void Update(GameTime gameTime)
        {

            Input.Input.Update(gameTime);
            inputSystem.Update(gameTime);
            activeScene.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            activeScene.Draw(gameTime);
        }

        public void ChangeScene(Scene newScene)
        {
            previousScene = activeScene;
            activeScene = newScene;
            activeScene.LoadContent(activeScene.name);
        }

    }
}
