using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    public abstract class Screen
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

        public abstract void Update(float dt);

        public abstract void Draw();
    }
}