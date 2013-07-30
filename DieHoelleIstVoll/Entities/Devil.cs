using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class Devil : Player
    {
        public Devil(Screen screen, Vector2 position)
            : base(screen, Global.Textures["devil"], position,Keys.Left,Keys.Right,Keys.Up)
        {
            direction = Soul.UP;
        }

        public override void Update(float dt)
        {
            base.update(dt);
        }
    }
}
