using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    enum PowerupType
    {
        Movement,
        Fire,
        Area
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
            }
            else if (type == PowerupType.Fire)
            {
            }
            else if (type == PowerupType.Movement)
            {
            }
        }

        public override void Update(float dt)
        {

        }
    }
}
