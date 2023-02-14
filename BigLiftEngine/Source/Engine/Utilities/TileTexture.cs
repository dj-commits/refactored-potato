using BigLiftEngine.Source.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Utilities
{
    public class TileTexture
    {
        public Texture2D TileSet { get; set; }

        public Rectangle TileFrame { get; set; }
        public int XFrame { get; set; }
        public int YFrame { get; set; }

        public Rectangle[,] TileFrames { get; set; }
        public float LayerDepth { get; set; }
        public TileTexture(Texture2D tileSet, int xFrame, int yFrame, int tileSizeX, int tileSizeY, float layerDepth,  DrawComponent drawC)
        {
            
            drawC.Origin = new Vector2(0, 0);
            drawC.Scale = new Vector2(1, 1);
            TileSet = tileSet;
            XFrame = xFrame;
            YFrame = yFrame;
            int FramesWidth = tileSet.Width / tileSizeX;
            int FramesHeight = tileSet.Height / tileSizeY;
            this.TileFrames = new Rectangle[FramesWidth, FramesHeight];
            this.LayerDepth = layerDepth;

            for (int i = 0; i < FramesWidth; i++)
            {
                for(int j = 0; j < FramesHeight; j++)
                {
                    TileFrames[i, j] = new Rectangle(i * FramesWidth, j * FramesHeight, tileSizeX, tileSizeY);
                }   
            }

            TileFrame = TileFrames[XFrame, YFrame];

        }
    }
}
