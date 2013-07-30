using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class Player : Entity
    {
        public Player(Vector2 position)
            : base(Global.Textures["player"], position, Color.White, 1.0f)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            //TODO
        }
    }
}
