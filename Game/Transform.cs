using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Transform
    {
        public Vector2 Position => position;
        public Vector2 Scale => scale;
        public float Angle => angle;

        private Vector2 position;
        private Vector2 scale;
        private float angle;

        public Transform(Vector2 position, Vector2 scale, float angle)
        {
            this.position = position;
            this.scale = scale;
            this.angle = angle;
        }
        public void Translate(Vector2 direction, float speed)
        {
            position.X += direction.X * speed * Program.deltaTime;
            position.Y += direction.Y * speed * Program.deltaTime;
        }
        public void Rotate(float speed)
        {
            angle += speed * Program.deltaTime;
        }
    }
}
