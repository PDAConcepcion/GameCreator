using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMap.Core
{
    internal class TileMapping
    {
        private Texture2D _textureAtlas;
        private Dictionary<Point, int> _tilemap;
        private List<Rectangle> _TextureStore;
        int tilewidth;
        int tileheight;

        public TileMapping(string filepath, int tileW, int tileH)
        {
            this.tilewidth = tileW;
            this.tileheight = tileH;
            _tilemap = LoadMap(filepath);
            
        }

        public void SetTextureAtlas(Texture2D textureAtlas)
        {
            _textureAtlas = textureAtlas;
            BuildTextureStore();
        }

        private void BuildTextureStore()
        {
            _TextureStore = new List<Rectangle>();
            if (_textureAtlas == null)
                return;

            int tilesPerRow = _textureAtlas.Width / tilewidth;
            int tilesPerCol = _textureAtlas.Height / tileheight;

            for (int y = 0; y < tilesPerCol; y++)
            {
                for (int x = 0; x < tilesPerRow; x++)
                {
                    _TextureStore.Add(new Rectangle(
                        x * tilewidth,
                        y * tileheight,
                        tilewidth,
                        tileheight
                    ));
                }
            }
        }

        private Dictionary<Point, int> LoadMap(string filepath)
        {
            Dictionary<Point, int> result = new();

            StreamReader reader = new(filepath);

            int y = 0;
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(',');
                for (int x = 0; x < items.Length; x++)
                {
                    if (int.TryParse(items[x], out int value))
                    {
                        if (value > -1)
                        {
                            result[new Point(x, y)] = value;
                        }
                    }
                }
                y++;
            }
            reader.Close();
            return result;
        }

        public void TileDraw(SpriteBatch sb, int windowWidth, int windowHeight)
        {
            int maxX = _tilemap.Keys.Max(p => p.X) + 1;
            int maxY = _tilemap.Keys.Max(p => p.Y) + 1;

            int display_tilesize = Math.Min(windowWidth / maxX, windowHeight / maxY);

            foreach (var item in _tilemap)
            {
                Rectangle dest = new(
                    item.Key.X * display_tilesize,
                    item.Key.Y * display_tilesize,
                    display_tilesize,
                    display_tilesize
                );

                int tileIndex = item.Value;
                Rectangle src;
                if (tileIndex >= 0 && tileIndex < _TextureStore.Count)
                {
                    src = _TextureStore[tileIndex];
                }
                else
                {
                    src = new Rectangle(0, 0, tilewidth, tileheight);
                }

                sb.Draw(_textureAtlas, dest, src, Color.White);
            }
        }
    }
}
