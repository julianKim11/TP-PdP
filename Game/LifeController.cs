using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LifeController
    {
        private int _maxHealth;
        private int currentLife;

        //public delegate void GetDamageDelegate();

        //public event GetDamageDelegate onGetDamage;
        public int CurrentLife
        {
            get => currentLife;
            set
            {
                currentLife = value;
                if (currentLife <= 0)
                {
                    GameManager.Instance.ChangeGameState(GameState.GameOverScreen);
                    LevelController.Reset();
                }
            }
        }
        public LifeController(int maxHealth)
        {
            _maxHealth = maxHealth;
        }
        public void GetDamage(int damage)
        {
            CurrentLife = currentLife - damage;
            //onGetDamage.Invoke();
            Engine.Debug(currentLife);
        }
    }
}
