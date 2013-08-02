using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class Soul : Entity
    {
        public const float SPEED = 300;
        public static float unvisiblecount = 0;
        public static float slowingcount=0;
        private bool isEvil;
        public bool IsEvil
        {
            get { return isEvil; }
            set
            {
                isEvil = value;

                if (isEvil)
                {
                    this.color = Color.Red;
                    this.rotation = MathHelper.Pi;
                }
                else
                {
                    this.color = Color.Blue;
                    this.rotation = 0;
                }
            }
        }
        public bool IsNew = false;

        public Soul(GameScreen screen, Vector2 position, bool isEvil)
            : base(screen, Global.Textures["soul"], position, Color.White, 1.0f)
        {
            this.IsEvil = isEvil; 
            
        }

        public Soul(GameScreen screen, Vector2 position, bool isEvil, bool isNew)
            : this(screen, position, isEvil)
        {
            this.IsNew = isNew;

            if (this.IsNew)
            {
                this.color = Color.White;
            }
        }

        public override void Update(float dt)
        {
            //Movement
            if (isEvil)
            {
                this.position.Y -= SPEED*(Soul.slowingcount<3?0.5f:1) * dt;
            }
            else
            {
                this.position.Y += SPEED * dt;
            }

            //Collision with blocks
            if (!this.IsNew)
            {
                foreach (Block b in screen.Blocks.Entities)
                {
                    if (this.Rectangle.Intersects(b.Rectangle))
                    {
                        if (!b.IsEvil) //lightning
                        {
                            this.IsEvil = !this.isEvil;
                        }
                        else if (b.IsEvil && !this.isEvil&&b.lifetime<0) //portal
                        {
                            this.Hit(screen.Petrus);
                        }
                    }
                }
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
            }
            else if (!isEvil && this.position.Y > Global.Height)
            {
                Hit(screen.Devil);
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
                Hit(player);
            }

            this.IsDestroying = true;
        }

        protected void Hit(Player player)
        {
            if (!this.IsNew)
            {
                Global.Sounds["hit"].Play();
                player.Hp--;
            }

            this.IsDestroying = true;
            NewSoul();
        }

        public override void Draw()
        {
            if (Soul.unvisiblecount < 3 && position.Y > Global.Height / 2 && !IsNew && isEvil)
            {
                return;
            }

            base.Draw();
        }
    }
}
