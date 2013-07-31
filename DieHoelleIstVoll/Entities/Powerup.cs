using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace DieHoelleIstVoll
{
    enum PowerupType
    {
        Area,
        Fire,
        Move
    }

    class Powerup : Entity
    {
        public const float SPEED = 300;

        private PowerupType type;
        private bool isActive = false;

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

            if (isActive)
            {
                if (!isEvil)
                {
                    this.position.Y -= SPEED * dt;
                }
                else
                {
                    this.position.Y += SPEED * dt;
                }
            }
            else
            {
                foreach (Soul s in souls)
                {
                    if (this.Rectangle.Intersects(s.Rectangle) && !s.IsNew)
                    {
                        if (this.isEvil == s.IsEvil)
                        {
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
    }
}
