using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class Soul : Entity
    {
        public Soul(Vector2 position)
            : base(Global.Textures["soul"], position, Color.White, 1.0f)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            //TODO
        }
    }
}
