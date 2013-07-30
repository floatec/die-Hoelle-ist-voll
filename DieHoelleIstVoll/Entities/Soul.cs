using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class Soul : Entity
    {
        public const int UP = -1;
        public const int DOWN = 1;
        public const float SPEED = 200.0f;   

        private int direction;

        public Soul(Screen screen, Vector2 position, int direction)
            : base(screen, Global.Textures["soul"], position, Color.White, 1.0f)
        {
            this.direction = direction;

            if (direction == UP)
            {
                this.rotation = MathHelper.Pi;
            }
        }

        public override void Update(float dt)
        {
            this.position.Y += SPEED * direction * dt;

            if (this.position.Y + this.texture.Height < 0 || this.position.Y > Global.Height)
            {
                this.IsDestroying = true;
            }
        }
        
    }
}
