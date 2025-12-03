using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace SlimeKingTrial.Components
{
    internal class Button
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Action OnClick;
        public float Scale = 0.3f;

        private MouseState _prevMouse;

        public Button(Texture2D texture, Vector2 position, Action onClick)
        {
            Texture = texture;
            Position = position;
            OnClick = onClick;
        }

        public void Update()
        {
            MouseState m = Mouse.GetState();
            Rectangle bounds = new Rectangle((int)Position.X,(int)Position.Y, Texture.Width, Texture.Height);
            if (bounds.Contains(m.Position) &&
                m.LeftButton == ButtonState.Pressed &&
                _prevMouse.LeftButton == ButtonState.Released)
            {
                OnClick?.Invoke();
            }
            _prevMouse = m;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero,Scale, SpriteEffects.None, 0f);
        }
    }
}
