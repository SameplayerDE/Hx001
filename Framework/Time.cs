using Microsoft.Xna.Framework;

namespace Hx001.Framework
{
    public static class Time
    {

        public static float DeltaTime;
        public static float FixedDeltaTime;

        public static void Update(GameTime gameTime)
        {
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

    }
}