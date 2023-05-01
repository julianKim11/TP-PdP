using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player
    {
        private string image;
        private float movementSpeed;
        private Vector2 offset;
        private Transform transform;


        public Player(string image, Vector2 position, Vector2 scale, float angle, Vector2 imageSize)
        {
            this.image = image;
            transform = new Transform(position, scale, angle);
            this.offset = new Vector2 ( scale.X * imageSize.X, scale.Y * imageSize.Y );

            movementSpeed = 200f;
        }
        public void Update()
        {
            InputReading();
        }
        public void Render()
        {
            Engine.Draw("Textures/Player/NaveTop.png", transform.Position.X, transform.Position.Y, 
                        transform.Scale.X, transform.Scale.Y, transform.Angle, offset.X, offset.Y);
        }
        private void InputReading()
        {
            if (Engine.GetKey(Keys.W)) transform.Translate(Vector2.VectorUp, movementSpeed);
            if (Engine.GetKey(Keys.S)) transform.Translate(Vector2.VectorDown, movementSpeed);
            if (Engine.GetKey(Keys.D)) transform.Translate(Vector2.VectorRight, movementSpeed);
            if (Engine.GetKey(Keys.A)) transform.Translate(Vector2.VectorLeft, movementSpeed);
        }
    }
}
