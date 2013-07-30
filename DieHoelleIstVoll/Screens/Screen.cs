using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    abstract class Screen
    {
        protected static MainGame game;
        protected static SpriteBatch spriteBatch;

        public static void Initialize()
        {
            Screen.game = Global.Game;
            Screen.spriteBatch = Global.SpriteBatch;
        }

        public Screen()
        {

        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);
    }
}