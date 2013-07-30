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
        public const float SPEED = 300;

        private SoulEffect effect;
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

            //Collision with player
            if (isEvil && this.Rectangle.Intersects(screen.Petrus.Rectangle))
            {
                Catch(screen.Petrus);
            }
            else if (!isEvil && this.Rectangle.Intersects(screen.Devil.Rectangle))
            {
                Catch(screen.Devil);
            }

            //Collision with screen
            if (isEvil && this.position.Y + this.texture.Height < 0)
            {
                Hit(screen.Petrus);
                screen.Souls.Add(new Soul(screen, new Vector2(Global.rand.Next(0, Global.Width),  Global.Height /2), Global.rand.Next(0, 2) == 0));
        
            }
            else if (!isEvil && this.position.Y > Global.Height)
            {
                
                Hit(screen.Devil);
            }
        }

        protected void Catch(Player player)
        {
            if (player.SoulCount < Player.MAX_SOUL)
            {
                player.SoulCount++;
            }
            else
            {
                Hit(player);
            }

            this.IsDestroying = true;
        }

        protected void Hit(Player player)
        {
            player.Hp--;
            this.IsDestroying = true;
        }
    }
}
