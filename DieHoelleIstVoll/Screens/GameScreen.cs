using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DieHoelleIstVoll
{
    class GameScreen : Screen
    {
        public Player Petrus;
        public Player Devil;   
        public EntityManager Souls;

        private Texture2D background;
        float gametime = 0;

        public GameScreen()
        {
            background = Global.Textures["background"];
            

            Petrus = new Player(this, new Vector2(300, 40), false);
            Devil = new Player(this, new Vector2(300, 510), true);
            Souls = new EntityManager();
        }

        public override void Update(float dt)
        {
            gametime += dt;
            Petrus.Update(dt);
            Devil.Update(dt);
            Souls.Update(dt);  
        }

        public override void Draw()
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            
            Petrus.Draw();
            Devil.Draw();
            Souls.Draw();
            drawInterface();
            float grey = -(float)((gametime * 0.5 * gametime * 0.5 - 0.4 - 1.5 * gametime * 0.5));
            spriteBatch.Draw(Global.Textures["howto"], Vector2.Zero, new Color(grey,grey,grey,grey));
            
        }

        private void drawInterface()
        {
            //souls
            //petrus
            for (int i = 0; i < Petrus.SoulCount; i++)
            {
                spriteBatch.Draw(Global.Textures["soulicon"], new Vector2(Global.Width - Global.Textures["soulicon"].Width*(i+1), 0), Color.White);
            }
            for (int i = Petrus.SoulCount;i<Player.MAX_SOUL ; i++)
            {
                spriteBatch.Draw(Global.Textures["soulicongrey"], new Vector2(Global.Width - Global.Textures["soulicon"].Width * (i + 1), 0), Color.White);
            }
            //devil
            for (int i = 0; i < Devil.SoulCount; i++)
            {
                spriteBatch.Draw(Global.Textures["soulicon"], new Vector2(Global.Width - Global.Textures["soulicon"].Width * (i + 1), Global.Height - Global.Textures["soulicon"].Height), Color.White);
            }
            for (int i = Devil.SoulCount; i < Player.MAX_SOUL; i++)
            {
                spriteBatch.Draw(Global.Textures["soulicongrey"], new Vector2(Global.Width - Global.Textures["soulicon"].Width * (i + 1), Global.Height - Global.Textures["soulicon"].Height), Color.White);
            }
            //HP
            //petrus
            for (int i = 0; i < Petrus.Hp; i++)
            {
                spriteBatch.Draw(Global.Textures["heiligenschein"], new Vector2( Global.Textures["heiligenschein"].Width * (i ), 0), Color.White);
            }
            for (int i = Petrus.Hp; i < Player.MAX_HP; i++)
            {
                spriteBatch.Draw(Global.Textures["heiligenscheingrey"], new Vector2(Global.Textures["heiligenscheingrey"].Width * (i ), 0), Color.White);
            }
            //devil
            for (int i = 0; i < Devil.Hp; i++)
            {
                spriteBatch.Draw(Global.Textures["dreizack"], new Vector2( Global.Textures["dreizack"].Width * (i ), Global.Height - Global.Textures["dreizack"].Height), Color.White);
            }
            for (int i = Devil.Hp; i < Player.MAX_HP; i++)
            {
                spriteBatch.Draw(Global.Textures["dreizackgrey"], new Vector2( Global.Textures["dreizack"].Width * (i ), Global.Height - Global.Textures["soulicon"].Height), Color.White);
            }
        }
    }
}
