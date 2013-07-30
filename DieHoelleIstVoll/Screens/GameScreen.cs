using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                int dir = Global.rand.Next(0, 2) == 0 ? 1 : -1;
                souls.Add(new Soul(new Vector2(Global.rand.Next(0, Global.Height), dir == 1 ? 1 : Global.Height - 50), dir));
            }
            petrus.Update(gameTime);
            devil.Update(gameTime);
            souls.Update(gameTime);
           
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            petrus.Draw(gameTime);
            devil.Draw(gameTime);
            souls.Draw(gameTime);
        }
    }
}
