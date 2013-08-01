using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace DieHoelleIstVoll
{
  class SplashScreen : Screen
    {
        public SplashScreen()     
        {
           
        }

        public override void Update(float dt)
        {
            if (Keyboard.GetState().GetPressedKeys().Length >= 1)
            {
                game.Screen = new MenuScreen();
            }
        }

        public override void Draw()
        {
            spriteBatch.Draw(Global.Textures["splashscreen"], Vector2.Zero, Color.White);
        }
    }

}
