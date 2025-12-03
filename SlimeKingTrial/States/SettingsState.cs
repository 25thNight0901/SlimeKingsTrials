using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SlimeKingTrial.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeKingTrial.States
{
    internal class SettingsState : IGameState
    {
        private ContentManager _content;
        private GameStateManager _manager;

        public SettingsState(ContentManager content, GameStateManager manager)
        {
            _content = content;
            _manager = manager;
        }

        public void LoadContent()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
