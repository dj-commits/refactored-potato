using BigLiftEngine.Source.Engine.Entities;
using BigLiftEngine.Source.Engine.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigLiftEngine.Source.Engine.Components
{
    public class GridComponent : Component
    {
        public int GridSizeX { get; set; }
        public int GridSizeY { get; set; }

        public Vector2Int[,] tiles;

        public GridComponent(Entity entity) : base(entity)
        {
            Entity = entity;

        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void ReceiveMessage(int message)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void GenerateGrid(int tileSizeX, int tileSizeY)
        {
            tiles = new Vector2Int[GridSizeX / tileSizeX, GridSizeY / tileSizeY];
            for(int i = 0; i < GridSizeX / tileSizeX; i++)
            {
                for(int j = 0; j < GridSizeY / tileSizeY; j++)
                {
                    tiles[i, j] = new Vector2Int(tileSizeX * i, tileSizeY * j);
                }
                
            }

        }
    }
}
