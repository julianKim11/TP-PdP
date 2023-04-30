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
        private float posX, posY;
        private float movementSpeed;
        private float scaleX, scaleY;
        private float angle;
        private float pivotX, pivotY;

        public Player(string image, float posX, float posY, float scaleX, float scaleY, float angle, float pivotX, float pivotY)
        {
            this.image = image;
            this.posX = posX;
            this.posY = posY;
            this.scaleX = scaleX;
            this.scaleY = scaleY;
            this.angle = angle;
            this.pivotX = pivotX;
            this.pivotY = pivotY;

            movementSpeed = 150f;
        }
        public void Update()
        {
            InputReading();
        }
        public void Render()
        {
            Engine.Draw("Textures/Player/NaveTop.png", posX, posY, scaleX, scaleY, angle, pivotX, pivotY);
        }
        private void InputReading()
        {
            if (Engine.GetKey(Keys.W)) posY -= movementSpeed * Program.deltaTime;
            if (Engine.GetKey(Keys.S)) posY += movementSpeed * Program.deltaTime;
            if (Engine.GetKey(Keys.D)) posX += movementSpeed * Program.deltaTime;
            if (Engine.GetKey(Keys.A)) posX -= movementSpeed * Program.deltaTime;
        }
    }
}
