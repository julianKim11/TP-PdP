using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class InputManager
    {
        private Character _player;
        private string checkDirection = "UP";

        public InputManager(Character player)
        {
            _player = player;
        }
        public void InputReading()
        {
            if (_player.MovementSpeed > 0)
            {
                if (Engine.GetKey(Keys.W) && checkDirection == "LEFT" || Engine.GetKey(Keys.W) && checkDirection == "RIGHT")
                {
                    checkDirection = "UP";
                    _player.Direction = new Vector2(0, -1);
                    _player.Transform.Rotate(0f);
                }
                if (Engine.GetKey(Keys.S) && checkDirection == "LEFT" || Engine.GetKey(Keys.S) && checkDirection == "RIGHT")
                {
                    checkDirection = "DOWN";
                    _player.Direction = new Vector2(0, 1);
                    _player.Transform.Rotate(180f);
                }
                if (Engine.GetKey(Keys.A) && checkDirection == "UP" || Engine.GetKey(Keys.A) && checkDirection == "DOWN")
                {
                    checkDirection = "LEFT";
                    _player.Direction = new Vector2(-1, 0);
                    _player.Transform.Rotate(-90f);
                }
                if (Engine.GetKey(Keys.D) && checkDirection == "UP" || Engine.GetKey(Keys.D) && checkDirection == "DOWN")
                {
                    checkDirection = "RIGHT";
                    _player.Direction = new Vector2(1, 0);
                    _player.Transform.Rotate(90f);
                }
            }
        }
    }
}
