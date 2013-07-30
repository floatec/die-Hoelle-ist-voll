using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    abstract class Player : Entity
    {
        protected const float SPEED = 300; 

        public Player(Texture2D texture, Vector2 position)
            : base(texture, position, Color.White, 1.0f)
        {
        }

        protected void Move(float amount)
        {
            if ((amount < 0 && this.position.X > 0) 
                || (amount > 0 && this.position.X + this.texture.Width < Global.Width))
            {
                this.position.X += amount;
            }
        }
    }
}
