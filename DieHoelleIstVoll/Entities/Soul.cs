using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class Soul : Entity
    {
        public const int DOWN = 1;
        public const int UP = -1;
        private int Direction;
        public const float SPEED = 0.5f;   
        public Soul(Vector2 position, int direction)
            : base(Global.Textures["soul"], position, Color.White, 1.0f)
        {
            this.Direction = direction;
            if (direction == UP)
            {
                base.rotate = MathHelper.Pi;
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.position.Y += SPEED*Direction;
            if (base.position.Y < 0 || base.position.Y > Global.Height)
            {
                base.IsDestroying = true;
            }
        }
        
    }
}
