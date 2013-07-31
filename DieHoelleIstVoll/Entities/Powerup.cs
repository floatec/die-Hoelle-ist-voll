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
        private PowerupType type;

        private bool isEvil;
        public bool IsEvil
        {
            get { return isEvil; }
            set
            {
                isEvil = value;

                if (isEvil)
                {
                    this.color = Color.Magenta;
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

            foreach (Soul s in souls)
            {
                if (this.Rectangle.Intersects(s.Rectangle))
                {
                    //TODO
                }
            }
        }
    }
}
