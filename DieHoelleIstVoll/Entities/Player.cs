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

        public float currentspeed=SPEED;
        public float throwcount = 0;
        public bool IsEvil;
        public int SoulCount = 3;
        public int Hp = 5;
        public PowerupType PowerUp = PowerupType.None;
        public float speedcooldown;
        protected bool triggered = false;
        protected Keys keyLeft;
        protected Keys keyRight;
        protected Keys keyThrow;
        protected Keys keyPowerup;

        public Player(GameScreen screen, Vector2 position, bool isEvil)
            : base(screen, isEvil ? Global.Textures["devil"] : Global.Textures["petrus"], position, Color.White, 1.0f)
        {
            if (isEvil)
            {
                this.keyLeft = Keys.Left;
                this.keyRight = Keys.Right;
                this.keyThrow = Keys.Up;
                this.keyPowerup = Keys.Down;
            }
            else
            {
                this.keyLeft = Keys.A;
                this.keyRight = Keys.D;
                this.keyThrow = Keys.S;
                this.keyPowerup = Keys.W;
            }

            this.IsEvil = isEvil;
        }

        public override void Update(float dt)
        {
            KeyboardState keyState = Keyboard.GetState();
            throwcount += dt;
            speedcooldown += dt;
            if (keyState.IsKeyDown(keyLeft) && this.position.X > 0)
            {
                this.position.X -=(speedcooldown<3?currentspeed : SPEED) * dt;
            }
            else if (keyState.IsKeyDown(keyRight) && this.position.X + this.texture.Width < Global.Width)
            {
                this.position.X += (speedcooldown < 3 ? currentspeed : SPEED) * dt;
            }
            if (keyState.IsKeyDown(keyPowerup))
            {
                usePowerup();
                PowerUp = PowerupType.None;
                
            }

            if (!triggered && keyState.IsKeyDown(keyThrow)&&throwcount>0.7)
            {
                throwcount = 0;
                triggered = true;
                if (SoulCount > 0)
                {
                    Global.Sounds["throw"].Play();
                    SoulCount--;
                    screen.Souls.Add(new Soul(screen, new Vector2(position.X+texture.Width/2-Global.Textures["soul"].Width/2, position.Y), this.IsEvil));
                 }
            }

            if (keyState.IsKeyUp(keyThrow))
            {
                triggered = false;
            }
        }
        private void usePowerup()
        {
            if (this.PowerUp == PowerupType.Move && this.IsEvil)
            {
                Player petrus = ((GameScreen)screen).Petrus;
                petrus.speedcooldown = 0;
                petrus.currentspeed = Player.SPEED * 0.5f;
            }
            else if (this.PowerUp == PowerupType.Move && !this.IsEvil)
            {
                this.speedcooldown = 0;
                this.currentspeed = Player.SPEED * 1.5f;
            }
            else if (this.PowerUp == PowerupType.Fire && this.IsEvil)
            {
                Soul.unvisiblecount = 0;
            }
            else if (this.PowerUp == PowerupType.Fire && !this.IsEvil)
            {
                Soul.slowingcount = 0; ;
            }
            else if (this.PowerUp == PowerupType.Area && this.IsEvil)
            {
                screen.Blocks.Add(new Block(screen, new Vector2(position.X, position.Y), true));
            }
            else if (this.PowerUp == PowerupType.Area && !this.IsEvil)
            {
                screen.Blocks.Add(new Block(screen, new Vector2(0, 90), false));
            }
        }
       
    }
}
