using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum ILaser
    {
        Horizontal,
        Vertical
    }
    public static class LaserFactory
    {
        public static Limit CreateLimit(ILaser laserType, Vector2 position)
        {
            switch (laserType)
            {
                case ILaser.Horizontal: 
                    return new Limit(position, new Vector2(1f, 1f), 0); // , new Vector2(1280 / 2, 715)
                case ILaser.Vertical:
                    return new Limit(position, new Vector2(1f, 1f), 90); //  new Vector2(5, 720 / 2)
            }
            return null;
        }
    }
}
