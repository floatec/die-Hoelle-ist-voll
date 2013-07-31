using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace DieHoelleIstVoll
{
    class Global
    {
        public static MainGame Game;
        public static SpriteBatch SpriteBatch;
        public static Random rand=new Random();

        public const int Width = 800;
        public const int Height = 600;

        public static Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();
        public static Dictionary<string, SoundEffect> Sounds = new Dictionary<string, SoundEffect>();
        public static Dictionary<string, SpriteFont> Fonts = new Dictionary<string, SpriteFont>();
    }
}
