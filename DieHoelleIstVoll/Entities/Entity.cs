using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    abstract class Entity
    {
        protected static MainGame game;
        protected static SpriteBatch spriteBatch;

        protected Texture2D texture;
        protected Vector2 position;
        protected Color color;
        protected float scale;

        public EntityManager EntityManager
        {
            get;
            set;
        }

        public bool IsDestroying
        {
            get;
            set;
        }

        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y,
                       (int)(texture.Width * scale), (int)(texture.Height * scale));
            }
        }

        public static void Initialize()
        {
            Entity.game = Global.Game;
            Entity.spriteBatch = Global.SpriteBatch;
        }

        public Entity(Texture2D texture, Vector2 position, Color color, float scale)
        {
            this.texture = texture;
            this.color = color;
            this.scale = scale;
            this.position = position;
        }

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, null, color, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 1.0f);
        }
    }
}
