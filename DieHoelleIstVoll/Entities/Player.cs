using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    abstract class Player : Entity
    {
        protected const float SPEED = 300;
        public const int MAX_SOUL = 5;
        public const float MAX_HP = 5;

        protected bool triggered = false;
        protected Keys keyLeft;
        protected Keys keyRight;
        protected Keys keyThrow;
        protected int direction=Soul.DOWN;
        public int soulCount = 3;
        public int hp = 5;

        public Player(Screen screen, Texture2D texture, Vector2 position,Keys keyLeft,Keys keyRight,Keys keyThrow)
            : base(screen, texture, position, Color.White, 1.0f)
        {
            this.keyLeft = keyLeft;
            this.keyRight = keyRight;
            this.keyThrow = keyThrow;
        }

        protected void Move(float amount)
        {
            if ((amount < 0 && this.position.X > 0) 
                || (amount > 0 && this.position.X + this.texture.Width < Global.Width))
            {
                this.position.X += amount;
            }
        }
        protected void update(float dt)
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(keyLeft))
            {
                Move(-SPEED * dt);
            }
            else if (keyState.IsKeyDown(keyRight))
            {
                Move(SPEED * dt);
            }

            if (!triggered && keyState.IsKeyDown(keyThrow))
            {
                triggered = true;
                if (soulCount > 0)
                {
                    soulCount--;
                    SpawnSoul(direction);
                }
            }
            if (keyState.IsKeyUp(keyThrow))
            {
                triggered = false;
            }
        }

        protected void SpawnSoul(int direction){

            ((GameScreen)screen).souls.Add(new Soul(screen, new Vector2(position.X, position.Y), direction));
        }
    }
}
