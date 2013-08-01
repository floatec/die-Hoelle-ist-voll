using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DieHoelleIstVoll
{
    class Block : Entity
    {
        public bool IsEvil;
        public float lifetime = 3;

        public Block(GameScreen screen, Vector2 position, bool isEvil)
            : base(screen, isEvil ? Global.Textures["portal_spawn"] : Global.Textures["lightning"], position, Color.White, 1.0f)
        {
            this.IsEvil = isEvil;
        }

        public override void Update(float dt)
        {
            lifetime -= dt;

            if (lifetime <= (IsEvil?-3:0))
            {
                this.IsDestroying = true;
            }
            if(lifetime<0){
                this.texture=Global.Textures["portal"];
            }
        }
    }
}
