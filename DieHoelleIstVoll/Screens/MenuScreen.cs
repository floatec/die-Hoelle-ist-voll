using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DieHoelleIstVoll
{
  class MenuScreen : Screen
    {

      private int state=0;
      private bool pressed=true;
      private float count=0;
        public MenuScreen()     
        {
           
        }

        public override void Update(float dt)
        {
            count += dt;
            if (Keyboard.GetState().IsKeyDown(Keys.Up)&&!pressed)
            {
                pressed = true;
                if (state > 0)
                {
                    state--;
                }
                //game.Screen = new GameScreen();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && !pressed)
            {
                pressed = true;
                if (state <5)
                {
                    state++;
                }
            }
            if (!pressed
                &&(Keyboard.GetState().IsKeyDown(Keys.Enter) || Keyboard.GetState().IsKeyDown(Keys.Space)))
            {
                if (state < 4)
                {
                    GameScreen gs=new GameScreen();
                    gs.level = state;
                    game.Screen = gs;
                }
                else if (state == 4)
                {
                    game.Screen = new CreditsScreen();
                }
                else
                {
                    game.Exit();
                }
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Enter) && Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                pressed=false;
            }

        }

        public override void Draw()
        {
            spriteBatch.Draw(Global.Textures["background"], Vector2.Zero, Color.White);
            string middle = "EASY";
            Vector2 dif = Global.Fonts["menu"].MeasureString(middle);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X) / 2, (dif.Y) * 0 + 30), state == 0 ? Color.Red : Color.LightGray);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X-3) / 2, (dif.Y) * 0 +27), state == 0 ? Color.Blue : Color.White);
            middle = "MIDDLE";
            dif = Global.Fonts["menu"].MeasureString(middle);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X) / 2, (dif.Y)*1 + 30), state == 1 ? Color.Red : Color.LightGray);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X-3) / 2, (dif.Y) * 1 +27), state == 1 ? Color.Blue : Color.White);
            middle = "HARD";
            dif = Global.Fonts["menu"].MeasureString(middle);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X) / 2, (dif.Y) * 2 + 30), state == 2 ? Color.Red : Color.LightGray);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X-3) / 2, (dif.Y) * 2 +27), state == 2 ? Color.Blue : Color.White);
            middle= "EVIL";
            dif = Global.Fonts["menu"].MeasureString(middle);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X) / 2, (dif.Y) * 3 + 30), state == 3 ? Color.Red : Color.LightGray);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X -3) / 2, (dif.Y) * 3 +27), state == 3 ? Color.Blue : Color.White);
            middle = "CREDITS";
            dif = Global.Fonts["menu"].MeasureString(middle);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X) / 2, (dif.Y) * 4 + 30), state == 4 ? Color.Red : Color.LightGray);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X -3) / 2, (dif.Y) * 4 +27), state == 4 ? Color.Blue : Color.White);
            middle = "EXIT";
            dif = Global.Fonts["menu"].MeasureString(middle);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X) / 2, (dif.Y) * 5 + 30), state == 5 ? Color.Blue : Color.LightGray);
            spriteBatch.DrawString(Global.Fonts["menu"], middle, new Vector2((Global.Width - dif.X -3) / 2, (dif.Y) * 5 +27), state == 5 ? Color.Blue : Color.White);
           
           
        }
    }

}
