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
        private bool isNew=false;

        public Soul(GameScreen screen, Vector2 position, bool isEvil)
            : base(screen, Global.Textures["soul"], position, Color.White, 1.0f)
        {
            this.isEvil = isEvil;
            this.color = Color.Blue;
            if (this.isEvil)
            {
                this.color = Color.Magenta;
                this.rotation = MathHelper.Pi;
            }
            
        }
        public Soul(GameScreen screen, Vector2 position, bool isEvil,bool isNew)
            : this(screen,position,isEvil)
        {
            this.isNew = isNew;
            if (this.isNew)
            {
                this.color = Color.Yellow;
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
                if (!this.isNew)
                {
                    Hit(screen.Petrus);
                }
                this.IsDestroying = true;
                NewSoul();
            }
            else if (!isEvil && this.position.Y > Global.Height)
            {
                 if(!this.isNew){
                 Hit(screen.Devil);
                }
                this.IsDestroying = true;
                NewSoul();
            }
        }
        protected void NewSoul()
        {
            screen.Souls.Add(new Soul(screen, new Vector2(Global.rand.Next(0, Global.Width - Global.Textures["soul"].Width), Global.Height / 2), Global.rand.Next(0, 2) == 0, true));
        }

        protected void Catch(Player player)
        {
            if (player.SoulCount < Player.MAX_SOUL)
            {
                player.SoulCount++;
            }
            else
            {
                NewSoul();
                if (!this.isNew)
                {
                    Hit(player);
                }
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
