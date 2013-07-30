using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class Petrus : Player
    {
        public Petrus(Screen screen, Vector2 position)
            : base(screen, Global.Textures["petrus"], position,Keys.A,Keys.D,Keys.S)
        {
        }

        public override void Update(float dt)
        {
            base.update(dt);
        }
    }
}
