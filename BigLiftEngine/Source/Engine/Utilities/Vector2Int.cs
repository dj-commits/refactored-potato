using Microsoft.Xna.Framework;
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
    public class Vector2Int
    {
        public int X;
        public int Y;
        public Vector2Int()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Vector2Int(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static explicit operator Vector2Int(Vector2 vector)
        {
            return new Vector2Int((int)vector.X, (int)vector.Y);

        }

    }
}
