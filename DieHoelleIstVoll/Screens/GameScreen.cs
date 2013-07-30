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

            petrus = new Petrus(new Vector2(0, 0));
            devil = new Devil(new Vector2(0, 550));
            souls = new EntityManager();
        }

        public override void Update(float dt)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                int dir = Global.rand.Next(0, 2) == 0 ? 1 : -1;
                souls.Add(new Soul(new Vector2(Global.rand.Next(0, Global.Height), dir == 1 ? 1 : Global.Height - 50), dir));
            }

            petrus.Update(dt);
            devil.Update(dt);
            souls.Update(dt);
           
        }

        public override void Draw()
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            petrus.Draw();
            devil.Draw();
            souls.Draw();
        }
    }
}
