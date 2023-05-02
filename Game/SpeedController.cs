using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class SpeedController
    {
        private Character _character;
        private bool _active = true;

        public SpeedController(Character character)
        {
            _character = character;
        }
        public void IncreaseSpeed()
        {
            if (_active)
            {
                _character.MovementSpeed += 0.2f;
            }
            if (_character.MovementSpeed >= 641f)
            {
                _active = false;
                _character.MovementSpeed = 0f;
                GameManager.Instance.ChangeGameState(GameState.WinScreen);
                LevelController.Reset();
            }
        }
    }
}
