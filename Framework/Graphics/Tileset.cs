using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx001.Framework.Graphics
{

    public struct Tile
    {
        public int X;
        public int Y;
        public Texture2D Tetxure;

        public Tile(int x, int y, Texture2D texture)
        {
            X = x;
            Y = y;
            Tetxure = texture;
        }
        
    }
    
    public class Tileset
    {

        private Texture2D _texture = null;
        public List<Tile> Tiles = new List<Tile>();

        public Tileset()
        {

        }

        public Tileset(Texture2D texture)
        {
            SetTexture(texture);
        }

        public void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }

        public Tile Get(int x, int y)
        {
            foreach (Tile tile in Tiles)
            {
                if (tile.X == x && tile.Y == y)
                {
                    return tile;
                }
            }

            return new Tile(-1, -1, null);
        }

        public Texture2D Create(GraphicsDevice graphicsDevice, int x, int y, int width, int height)
        {
            if (_texture == null)
            {
                return null;
            }
            Rectangle size = new Rectangle(x, y, width, height);

            Texture2D sprite = new Texture2D(graphicsDevice, width, height);
            Color[] data = new Color[width * height];
            _texture.GetData(0, size, data, 0, width * height);
            sprite.SetData(data);

            return sprite;
        }

        public void Create(GraphicsDevice graphicsDevice, int spriteW, int spriteH)
        {
            if (_texture == null)
            {
                return;
            }
            Rectangle size = new Rectangle(0, 0, spriteW, spriteH);

            int amountX = _texture.Width / spriteW;
            int amountY = _texture.Height / spriteH;

            for (int y = 0; y < amountY; y++)
            {
                size.Y = y;
                for (int x = 0; x < amountX; x++)
                {
                    size.X = x;
                    Texture2D sprite = new Texture2D(graphicsDevice, size.Width, size.Height);
                    Color[] data = new Color[size.Width * size.Height];
                    _texture.GetData(0, size, data, 0, size.Width * size.Height);
                    sprite.SetData(data);
                    Tiles.Add(new Tile(x, y, sprite));
                }
            }

        }

        public void CreateFromDesciption(string[] description)
        {
            if (_texture == null)
            {
                return;
            }
        }

    }
}