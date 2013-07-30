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
        float gametime = 0;

        public EntityManager souls;

        public GameScreen()
        {
            background = Global.Textures["background"];
            

            petrus = new Petrus(this, new Vector2(0, 0));
            devil = new Devil(this, new Vector2(0, 550));
            souls = new EntityManager();
        }

        public override void Update(float dt)
        {
            gametime += dt;
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                int dir = Global.rand.Next(0, 2) == 0 ? 1 : -1;
                souls.Add(new Soul(this, new Vector2(Global.rand.Next(0, Global.Height), dir == 1 ? 1 : Global.Height - 50), dir));
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
            drawInterface();
            float grey = -(float)((gametime * 0.5 * gametime * 0.5 - 0.4 - 1.5 * gametime * 0.5));
            spriteBatch.Draw(Global.Textures["howto"], Vector2.Zero, new Color(grey,grey,grey,grey));
            
        }

        private void drawInterface()
        {
            //souls
            //petrus
            for (int i = 0; i < petrus.soulCount; i++)
            {
                spriteBatch.Draw(Global.Textures["soulicon"], new Vector2(Global.Width - Global.Textures["soulicon"].Width*(i+1), 0), Color.White);
            }
            for (int i = petrus.soulCount;i<Player.MAX_SOUL ; i++)
            {
                spriteBatch.Draw(Global.Textures["soulicongrey"], new Vector2(Global.Width - Global.Textures["soulicon"].Width * (i + 1), 0), Color.White);
            }
            //devil
            for (int i = 0; i < devil.soulCount; i++)
            {
                spriteBatch.Draw(Global.Textures["soulicon"], new Vector2(Global.Width - Global.Textures["soulicon"].Width * (i + 1), Global.Height - Global.Textures["soulicon"].Height), Color.White);
            }
            for (int i = devil.soulCount; i < Player.MAX_SOUL; i++)
            {
                spriteBatch.Draw(Global.Textures["soulicongrey"], new Vector2(Global.Width - Global.Textures["soulicon"].Width * (i + 1), Global.Height - Global.Textures["soulicon"].Height), Color.White);
            }
            //HP
            //petrus
            for (int i = 0; i < petrus.hp; i++)
            {
                spriteBatch.Draw(Global.Textures["heiligenschein"], new Vector2( Global.Textures["heiligenschein"].Width * (i ), 0), Color.White);
            }
            for (int i = petrus.hp; i < Player.MAX_HP; i++)
            {
                spriteBatch.Draw(Global.Textures["heiligenscheingrey"], new Vector2(Global.Textures["heiligenscheingrey"].Width * (i ), 0), Color.White);
            }
            //devil
            for (int i = 0; i < devil.hp; i++)
            {
                spriteBatch.Draw(Global.Textures["dreizack"], new Vector2( Global.Textures["dreizack"].Width * (i ), Global.Height - Global.Textures["dreizack"].Height), Color.White);
            }
            for (int i = devil.hp; i < Player.MAX_HP; i++)
            {
                spriteBatch.Draw(Global.Textures["dreizackngrey"], new Vector2( Global.Textures["dreizackicon"].Width * (i ), Global.Height - Global.Textures["soulicon"].Height), Color.White);
            }
        }
    }
}
