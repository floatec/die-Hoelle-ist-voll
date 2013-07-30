using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class Player : Entity
    {
        protected const float SPEED = 500;
        public const int MAX_SOUL = 5;
        public const float MAX_HP = 5;

        public bool IsEvil;
        public int SoulCount = 3;
        public int Hp = 5;

        protected bool triggered = false;
        protected Keys keyLeft;
        protected Keys keyRight;
        protected Keys keyThrow;

        public Player(GameScreen screen, Vector2 position, bool isEvil)
            : base(screen, isEvil ? Global.Textures["devil"] : Global.Textures["petrus"], position, Color.White, 1.0f)
        {
            if (isEvil)
            {
                this.keyLeft = Keys.Left;
                this.keyRight = Keys.Right;
                this.keyThrow = Keys.Up;
            }
            else
            {
                this.keyLeft = Keys.A;
                this.keyRight = Keys.D;
                this.keyThrow = Keys.S;
            }

            this.IsEvil = isEvil;
        }

        public override void Update(float dt)
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(keyLeft) && this.position.X > 0)
            {
               this.position.X -= SPEED * dt;
            }
            else if (keyState.IsKeyDown(keyRight) && this.position.X + this.texture.Width < Global.Width)
            {
                this.position.X += SPEED * dt;
            }

            if (!triggered && keyState.IsKeyDown(keyThrow))
            {
                triggered = true;
                if (SoulCount > 0)
                {
                    Global.Sounds["throw"].Play();
                    SoulCount--;
                    screen.Souls.Add(new Soul(screen, new Vector2(position.X, position.Y), this.IsEvil));
                }
            }

            if (keyState.IsKeyUp(keyThrow))
            {
                triggered = false;
            }
        }

       
    }
}
