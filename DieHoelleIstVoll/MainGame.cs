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

        Screen screen;

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

            screen = new GameScreen();
        }

        protected override void Update(GameTime gameTime)
        {
            float dt = gameTime.ElapsedGameTime.Milliseconds / 1000.0f;

            screen.Update(dt);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            spriteBatch.Begin();
            screen.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
