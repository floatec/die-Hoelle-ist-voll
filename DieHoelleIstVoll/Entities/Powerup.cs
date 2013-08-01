using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DieHoelleIstVoll
{
    enum PowerupType
    {
        None,
        Area,
        Fire,
        Move
    }

    class Powerup : Entity
    {
        public const float SPEED = 300;

        private PowerupType type;
        private bool isActive = false;
        private float lifetime = 0;

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

        public Powerup(GameScreen screen, Vector2 position, bool isEvil, PowerupType type) :
            base(screen, Global.Textures["powerup"], position, Color.White, 1.0f)
        {
            Global.Sounds["powerup"].Play();
            this.IsEvil = isEvil;
            this.type = type;

            if (type == PowerupType.Area)
            {
                this.texture = Global.Textures["powerupArea"];
            }
            else if (type == PowerupType.Fire)
            {
                this.texture = Global.Textures["powerupFire"];
            }
            else if (type == PowerupType.Move)
            {
                this.texture = Global.Textures["powerupMove"];
            }
        }

        public override void Update(float dt)
        {
            List<Soul> souls = this.screen.Souls.Entities;
            lifetime += dt;
           
            if (isActive)
            {
                lifetime += dt;
                if (!isEvil)
                {
                    this.position.Y -= SPEED * dt;
                }
                else
                {
                    this.position.Y += SPEED * dt;
                }

                if (this.Rectangle.Intersects(screen.Devil.Rectangle))
                {
                    Pickup(screen.Devil);
                }
                else if (this.Rectangle.Intersects(screen.Petrus.Rectangle))
                {
                    Pickup(screen.Petrus);
                }
            }
            else
            {
                if (lifetime > Math.PI)
                {
                    lifetime = 0;
                    IsEvil = !isEvil;
                }

                float alpha = (float)Math.Sin(lifetime);
                Vector4 col = this.color.ToVector4();
                col.W = alpha;
                this.color = new Color(col);

                foreach (Soul s in souls)
                {
                    if (this.Rectangle.Intersects(s.Rectangle) && !s.IsNew)
                    {
                        if (this.isEvil == s.IsEvil)
                        {
                            col.W = 1;
                            this.color = new Color(col);
                            this.isActive = true;
                        }
                        else
                        {
                            //Reflect
                            s.IsEvil = !s.IsEvil;
                        }
                    }
                }
            }
        }

        private void Pickup(Player player)
        {
            player.PowerUp = this.type;
            this.IsDestroying = true;
        }
    }
}
