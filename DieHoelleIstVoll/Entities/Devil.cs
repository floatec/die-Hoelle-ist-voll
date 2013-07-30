using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class Devil : Player
    {
        public Devil(Vector2 position)
            : base(Global.Textures["devil"], position)
        {
        }

        public override void Update(float dt)
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Left))
            {
                Move(-SPEED * dt);
            }
            else if (keyState.IsKeyDown(Keys.Right))
            {
                Move(SPEED * dt);
            }
        }
    }
}
