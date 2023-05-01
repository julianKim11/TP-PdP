using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public struct Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public static Vector2 VectorUp => new Vector2(0, -1);
        public static Vector2 VectorDown => new Vector2(0, 1);
        public static Vector2 VectorRight => new Vector2(1, 0);
        public static Vector2 VectorLeft => new Vector2(-1, 0);
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public string ToString() => $"Vector2 X: {X} / Y: {Y}";
    }
}
