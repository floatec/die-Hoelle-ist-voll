using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class GameScreen : Screen
    {
        Texture2D background;

        Player petrus;
        Player devil;

        EntityManager souls;

        public GameScreen()
        {
            background = Global.Textures["background"];

            petrus = new Player(new Vector2(300, 20));
            devil = new Player(new Vector2(300, 540));
            souls = new EntityManager();
        }

        public override void Update(GameTime gameTime)
        {
            petrus.Update(gameTime);
            devil.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            petrus.Draw(gameTime);
            devil.Draw(gameTime);
        }
    }
}
