using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class LevelController
    {
        private static Time _time;
        private static Character _player;
        public static Character Player => _player;
        private static List<Enemy> enemies = new List<Enemy>();
        private static void Start()
        {
            _time.Initialize();
            _player = new Character("Textures/Player/0NaveTop.png", new Vector2(1280 / 2, 720 / 2),
                                        new Vector2(.75f, .75f), 0, 100f, new Vector2(0, -1));
            enemies.Add(new Enemy("Textures/Player/0NaveTop.png", new Vector2(1280 / 2, 720 / 2),
                                        new Vector2(.75f, .75f), 0, 100f, new Vector2(0, -1)));
        }

        private static void Update()
        {
            _player.Update();
            foreach (Enemy enemy in enemies) enemy.Update();

            _time.Update();
        }

        public static void Render()
        {
            Engine.Clear();
            Engine.Draw("Textures/Background/FondoEspacial.png");
            _player.Render();
            foreach (Enemy enemy in enemies) enemy.Render();

            Engine.Show();
        }
    }
}
