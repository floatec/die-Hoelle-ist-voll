using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DieHoelleIstVoll
{
    public class MainGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Song music;

        public Screen Screen;

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = Global.Width;
            graphics.PreferredBackBufferHeight = Global.Height;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Global.Game = this;
            Global.SpriteBatch = spriteBatch;

            Entity.Initialize();
            Screen.Initialize();

            Global.Textures.Add("petrus", Content.Load<Texture2D>("petrus"));
            Global.Textures.Add("devil", Content.Load<Texture2D>("devil"));
            Global.Textures.Add("soul", Content.Load<Texture2D>("soul"));
            Global.Textures.Add("background", Content.Load<Texture2D>("background"));
            Global.Textures.Add("soulicon", Content.Load<Texture2D>("soulicon"));
            Global.Textures.Add("soulicongrey", Content.Load<Texture2D>("souliconGrau"));
            Global.Textures.Add("heiligenschein", Content.Load<Texture2D>("heiligenschein"));
            Global.Textures.Add("heiligenscheingrey", Content.Load<Texture2D>("heiligenscheinGrau"));
            Global.Textures.Add("dreizack", Content.Load<Texture2D>("dreizack"));
            Global.Textures.Add("dreizackgrey", Content.Load<Texture2D>("dreizackGrau"));
            Global.Textures.Add("howto", Content.Load<Texture2D>("howtooverley"));
            Global.Textures.Add("powerup", Content.Load<Texture2D>("powerup"));
            Global.Textures.Add("powerupArea", Content.Load<Texture2D>("powerupArea"));
            Global.Textures.Add("powerupFire", Content.Load<Texture2D>("powerupFire"));
            Global.Textures.Add("powerupMove", Content.Load<Texture2D>("powerupMove"));
            Global.Sounds.Add("throw",Content.Load<SoundEffect>("throw"));
            Global.Fonts.Add("count",Content.Load<SpriteFont>("countfont"));

            music = Content.Load<Song>("music");
            MediaPlayer.IsRepeating = true;
           // MediaPlayer.Play(music);

            Screen = new GameScreen();
        }

        protected override void Update(GameTime gameTime)
        {
            float dt = gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            Screen.Update(dt);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            spriteBatch.Begin();
            Screen.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
