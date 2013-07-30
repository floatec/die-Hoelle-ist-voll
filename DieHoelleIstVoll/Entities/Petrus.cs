using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class Petrus : Player
    {
        public Petrus(Screen screen, Vector2 position)
            : base(screen, Global.Textures["petrus"], position)
        {
        }

        public override void Update(float dt)
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.A))
            {
                Move(-SPEED * dt);
            }
            else if (keyState.IsKeyDown(Keys.D))
            {
                Move(SPEED * dt);
            }
            
            if (keyState.IsKeyDown(Keys.S))
            {
                SpawnSoul(Soul.DOWN);
            }
        }
    }
}
