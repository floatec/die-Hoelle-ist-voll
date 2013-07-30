using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    public enum SoulEffect
    {
        None
    }

    class Soul : Entity
    {
        public const float SPEED = 200.0f;
        private bool isEvil;

        public Soul(GameScreen screen, Vector2 position, bool isEvil)
            : base(screen, Global.Textures["soul"], position, Color.White, 1.0f)
        {
            this.isEvil = isEvil;

            if (isEvil)
            {
                this.rotation = MathHelper.Pi;
            }
        }

        public override void Update(float dt)
        {
            //Movement
            if (isEvil)
            {
                this.position.Y -= SPEED * dt;
            }
            else
            {
                this.position.Y += SPEED * dt;
            }

            //Delete
            if (this.position.Y + this.texture.Height < 0 || this.position.Y > Global.Height)
            {
                this.IsDestroying = true;
            }

            //Collision
            if (isEvil && this.Rectangle.Intersects(screen.Petrus.Rectangle))
            {
                Collide(screen.Petrus);
            }
            else if (!isEvil && this.Rectangle.Intersects(screen.Devil.Rectangle))
            {
                Collide(screen.Devil);
            }
        }

        protected void Collide(Player player)
        {
            player.Hp--;
            this.IsDestroying = true;
        }      
    }
}
