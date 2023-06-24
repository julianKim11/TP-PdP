using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum IAsteroid
    {
        Small,
        Medium,
        Large
    }
    public static class AsteroidFactory
    {
        public static Enemy CreateEnemy(IAsteroid asteroidType, Vector2 position)
        {
            switch (asteroidType)
            {
                case IAsteroid.Small:
                    return new Enemy(position, new Vector2(1f, 1f), 0, 0, new Vector2(0, -1));
                case IAsteroid.Medium:
                    return new Enemy(position, new Vector2(1f, 1f), 0, 0, new Vector2(0, -1));
                case IAsteroid.Large:
                    return new Enemy(position, new Vector2(1f, 1f), 0, 0, new Vector2(0, -1));
            }
            return null;
        }

    }
}
