using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    abstract class Player : Entity
    {
        protected const float SPEED = 300; 

        public Player(Screen screen, Texture2D texture, Vector2 position)
            : base(screen, texture, position, Color.White, 1.0f)
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

        protected void SpawnSoul(int direction){

            ((GameScreen)screen).souls.Add(new Soul(screen, new Vector2(position.X, position.Y), direction));
        }
    }
}
