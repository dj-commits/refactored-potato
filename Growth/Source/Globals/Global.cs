using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Growth.Source.Data;

namespace Growth.Source.Globals
{
    public static class Global
    {
        public static Vector2 textureOrigin;
        public static Vector2 textureScale;

        public static void Initialize()
        {
            textureOrigin = new Vector2(0, 0);
            textureScale = new Vector2(1, 1);
        }
    }
}
