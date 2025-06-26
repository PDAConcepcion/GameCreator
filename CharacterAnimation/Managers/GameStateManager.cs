using CharacterAnimation.Core;
using CharacterAnimation.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterAnimation.Managers
{
    internal partial class GameStateManager : Component
    {
        private MenuScene ms = new();
        private GameScene gs = new();

        internal override void LoadContent(ContentManager content)
        {
            ms.LoadContent(content);
            gs.LoadContent(content);
        }

        internal override void Update(GameTime gameTime)
        {
            switch (Data.CurrentState)
            {
                case Data.Scenes.Menu:
                    ms.Update(gameTime);
                    break;
                case Data.Scenes.Game:
                    gs.Update(gameTime);
                    break;
                case Data.Scenes.Settings:
                    break;
            }
        }
        internal override void Draw(SpriteBatch spriteBatch)
        {
            switch (Data.CurrentState)
            {
                case Data.Scenes.Menu:
                    ms.Draw(spriteBatch);
                    break;
                case Data.Scenes.Game:
                    ms.Draw(spriteBatch);
                    break;
                case Data.Scenes.Settings:
                    break;
            }
        }
    }
}
