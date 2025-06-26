using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using TileMap.Core;

namespace TileMap
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        int _TileSpriteWidth = 128;
        int _TileSpriteHeight = 128;

        TileMapping _tileMapMG;
        TileMapping _tileMapCo;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 900;
            _graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            _tileMapMG = new TileMapping(
                "../../../Data/TileMapping_mg.csv",
                _TileSpriteWidth,
                _TileSpriteHeight
                );
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D TilesAtlas = Content.Load<Texture2D>("PlatformAtlas");
            _tileMapMG.SetTextureAtlas(TilesAtlas);


        }

        protected override void Update(GameTime gameTime)
        {


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _tileMapMG.TileDraw(_spriteBatch, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
