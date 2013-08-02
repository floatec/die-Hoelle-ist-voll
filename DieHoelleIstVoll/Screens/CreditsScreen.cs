using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DieHoelleIstVoll
{
  class CreditsScreen : Screen
    {

      private int state=-1;
      private bool pressed=true;
      private float count=0;
        public CreditsScreen()     
        {
           
        }

        public override void Update(float dt)
        {
            count += dt;
           
            if (!pressed
                &&(Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Space)))
            {
                game.Screen = new MenuScreen();
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Enter) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                pressed=false;
            }

        }

        public override void Draw()
        {
            spriteBatch.Draw(Global.Textures["background"], Vector2.Zero, Color.White);
            string middle = "Marius Musch";
            Vector2 dif = Global.Fonts["menu"].MeasureString(middle);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X) / 2, (dif.Y) * 0 + 30), state == 0 ? Color.Red : Color.LightGray);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X-3) / 2, (dif.Y) * 0 +27), state == -1 ? Color.Blue : Color.White);
            middle = "Patrick Mueller";
            dif = Global.Fonts["menu"].MeasureString(middle);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X) / 2, (dif.Y)*1 + 30), state == 1 ? Color.Red : Color.LightGray);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X-3) / 2, (dif.Y) * 1 +27), state == -1 ? Color.Blue : Color.White);
            middle = "Ronny Froehlich";
            dif = Global.Fonts["menu"].MeasureString(middle);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X) / 2, (dif.Y) * 2 + 30), state == 2 ? Color.Red : Color.LightGray);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X-3) / 2, (dif.Y) * 2 +27), state == -1 ? Color.Blue : Color.White);
            
        }
    }

}
