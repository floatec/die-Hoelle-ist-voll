using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DieHoelleIstVoll
{
    class GameScreen : Screen
    {
        public const int ACTIVE=0;
        public const int GAMEOVER=1;
        public Player Petrus;
        public Player Devil;   
        public EntityManager<Soul> Souls;
        public EntityManager<Powerup> Powerups;

        private Texture2D background;
        float gametime = 0;
        float PowerupSpawmTime = 0;
        public int GameState = ACTIVE;

        public GameScreen()
        {
            background = Global.Textures["background"];
            

            Petrus = new Player(this, new Vector2(300, 40), false);
            Devil = new Player(this, new Vector2(300, 520), true);
            Souls = new EntityManager<Soul>();
            Powerups = new EntityManager<Powerup>();
        }

        public override void Update(float dt)
        {
            KeyboardState keyState = Keyboard.GetState();
            gametime += dt;
            Soul.unvisiblecount += dt;
            if (gametime >= 3 && GameState == ACTIVE)
            {
                Petrus.Update(dt);
                Devil.Update(dt);
            }

            Souls.Update(dt);
            Powerups.Update(dt);

            if (Petrus.Hp <= 0 || Devil.Hp <= 0)
            {
                GameState = GAMEOVER;
                if (keyState.IsKeyDown(Keys.Space))
                {
                    game.Screen = new GameScreen();
                }
            }
            PowerupSpawmTime += dt;
            if ((Global.rand.Next(0, 500) <= PowerupSpawmTime*1000&&dt>2)||PowerupSpawmTime>5)
            {
                PowerupSpawmTime = 0;
                Vector2 pos = new Vector2(Global.rand.Next(100, Global.Width-100), Global.Height / 2);
                bool evil = Global.rand.Next(0, 2) == 0 ? false : true;

                Array values = Enum.GetValues(typeof(PowerupType));
                PowerupType type;
                do
                {
                    type = (PowerupType)values.GetValue(Global.rand.Next(values.Length));
                } while (type==PowerupType.None);

                Powerups.Add(new Powerup(this, pos, evil, type));
            }
        }

        public override void Draw()
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            
            Petrus.Draw();
            Devil.Draw();
            Souls.Draw();
            Powerups.Draw();
            drawInterface();

            float grey = -(float)((gametime * 0.5 * gametime * 0.5 - 0.4 - 1.5 * gametime * 0.5));
            spriteBatch.Draw(Global.Textures["howto"], Vector2.Zero, new Color(grey,grey,grey,grey));
            string middle = (int)gametime < 3 ? (int)(4 - gametime)+"" : "go";   
            Vector2 dif = Global.Fonts["count"].MeasureString(middle);
            spriteBatch.DrawString(Global.Fonts["count"], middle, new Vector2((Global.Width - dif.X) / 2, (Global.Height - dif.Y) / 2), new Color(grey + 0.4f, grey + 0.4f, grey + 0.4f, grey + 0.4f));

            if (GameState == GAMEOVER)
            {
                dif = Global.Fonts["count"].MeasureString("GAMEOVER");
                spriteBatch.DrawString(Global.Fonts["count"], "GAMEOVER", new Vector2((Global.Width - dif.X) / 2, (Global.Height - dif.Y) / 2), Color.White);
                dif = Global.Fonts["count"].MeasureString("[SPACE] to try it again");
                spriteBatch.DrawString(Global.Fonts["count"], "[SPACE] to try it again", new Vector2((Global.Width - dif.X) / 2, (Global.Height - dif.Y+130) / 2), Color.White);

            }
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
            //powerup
            //petrus
            drawPowerup(new Vector2(0, Global.Textures["soulicon"].Height), Petrus, Color.Blue);
            drawPowerup(new Vector2(0, Global.Height - Global.Textures["soulicon"].Height - Global.Textures["powerup"].Height), Devil, Color.Red);
            
        }

        private void drawPowerup(Vector2 pos, Player player, Color col)
        {
            Texture2D toDraw = Global.Textures["powerup"];
            if (player.PowerUp == PowerupType.Area)
            {
                toDraw = Global.Textures["powerupArea"];
            }
            else if (player.PowerUp == PowerupType.Fire)
            {
                toDraw = Global.Textures["powerupFire"];
            }
            else if (player.PowerUp == PowerupType.Move)
            {
                toDraw = Global.Textures["powerupMove"];
            }
            spriteBatch.Draw(toDraw, pos, col);

        }
    }
}
