using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SlimeKingTrial.Components;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;
using SlimeKingTrial.Interfaces;

namespace SlimeKingTrial.States
{
    internal class MainMenuState : IGameState
    {
        private Texture2D _background;
        private List<Button> _buttons = new List<Button>();
        private ContentManager _content;
        private GameStateManager _manager;
        private GraphicsDevice _graphicsDevice;
        public MainMenuState(ContentManager content, GameStateManager manager, GraphicsDevice graphicsDevice)
        {
            _content = content;
            _manager = manager;
            _graphicsDevice = graphicsDevice;
        }

        public void LoadContent()
        {
            _background = _content.Load<Texture2D>("backgrounds/menuBackground");

            var startTexture = _content.Load<Texture2D>("buttons/startButton");
            var optionsTexture = _content.Load<Texture2D>("buttons/optionsButton");
            var quitTexture = _content.Load<Texture2D>("buttons/quitButton");

            int screenWidth = _graphicsDevice.Viewport.Width;
            int screenHeight = _graphicsDevice.Viewport.Height;

            int centerX = screenWidth / 2 + 150;
            int startY = screenHeight / 2 - 50;
            int spacing = 80;

            var startButton = new Button(
                startTexture,
                new Vector2(centerX - startTexture.Width /2, startY),
                () => _manager.ChangeState(new PlayState(_content, _manager))
                );
            var optionsButton = new Button(
                optionsTexture,
                new Vector2(centerX - startTexture.Width / 2, startY+ spacing),
                () => _manager.ChangeState(new SettingsState(_content, _manager))
                );
            var quitButton = new Button(
                quitTexture,
                new Vector2(centerX - startTexture.Width / 2, startY + 2*spacing),
                () => Environment.Exit(0)
                );

            _buttons.Add(startButton);
            _buttons.Add(optionsButton);
            _buttons.Add(quitButton);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var button in _buttons)
            {
                button.Update();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            float scaleX = (float)_graphicsDevice.Viewport.Width / _background.Width;
            float scaleY = (float)_graphicsDevice.Viewport.Height / _background.Height;
            spriteBatch.Draw(_background, Vector2.Zero,null, Color.White, 0f, Vector2.Zero, new Vector2(scaleX,scaleY), SpriteEffects.None, 0f);

            foreach (var buttons in _buttons)
            {
                buttons.Draw(spriteBatch);
            }
        }
    }
}
