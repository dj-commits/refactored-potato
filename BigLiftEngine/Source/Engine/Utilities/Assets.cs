using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Utilities
{
    public static class Assets
    {

        private static Dictionary<string, Effect> effects = new Dictionary<string, Effect>();
        private static Dictionary<string, SpriteFont> fonts = new Dictionary<string, SpriteFont>();
        private static Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public static Texture2D Texture(string name)
        {
            if (textures.ContainsKey(name))
            {
                return textures[name];
            }
            else
            {
                return null;
            }

        }

        public static SpriteFont Font(string name)
        {
            if (fonts.ContainsKey(name))
            {
                return fonts[name];
            }
            else
            {
                return null;
            }
        }
        public static Effect Effect(string name)
        {
            if (effects.ContainsKey(name))
            {
                return effects[name];
            }
            else
            {
                return null;
            }
        }

        public static void LoadAllAssets(ContentManager contentManager)
        {
            effects = LoadAssets<Effect>(contentManager, "Effects");
            fonts = LoadAssets<SpriteFont>(contentManager, "Fonts");
            textures = LoadAssets<Texture2D>(contentManager, "Textures");
        }
        private static string properMonoGameAssetPath(string path, string filename, string rootDir)
        {
            return Path.Combine(path.Substring(path.IndexOf(rootDir) + rootDir.Length), filename).Replace('\\', '/').Substring(1);
        }

        public static Dictionary<string, T> LoadAssets<T>(ContentManager ContentManager, string ContentDir)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(ContentManager.RootDirectory, ContentDir));
            if (!dir.Exists)
                throw new DirectoryNotFoundException();

            Dictionary<string, T> tmp = new Dictionary<string, T>();
            FileInfo[] files = dir.GetFiles("*.*", SearchOption.AllDirectories);
            foreach (FileInfo file in files)
            {
                string asset = properMonoGameAssetPath(file.DirectoryName, Path.GetFileNameWithoutExtension(file.Name), ContentManager.RootDirectory);
                tmp.Add(asset, ContentManager.Load<T>(asset));
            }
            return tmp;
        }
    }
}
