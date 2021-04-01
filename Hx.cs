using System;
using Hx001.Framework;
using Microsoft.Xna.Framework;

namespace Hx001
{
    public class Hx : GameComponent
    {
        public Hx(Game game) : base(game)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Time.Update(gameTime);
            Input.Update(gameTime);
        }
    }
}