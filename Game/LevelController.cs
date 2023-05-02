using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LevelController
    {
        private static Time _time;
        private static Character _player;
        private static LifeController _lifeController;
        public static Character Player => _player;
        public static LifeController LifeController => _lifeController;
        private static List<Enemy> enemies = new List<Enemy>();
        private static List<Limit> lasers = new List<Limit>();
        private static List<LimitVertical> lasersV = new List<LimitVertical>();
        public static void Start()
        {
            _time.Initialize();

            _player = new Character("Textures/Player/0NaveTop.png", new Vector2(1280 / 2, 720 / 2), new Vector2(0.75f, 0.75f), 0, 100f, new Vector2(0, -1), 1);

            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(150, 150), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(900, 200), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(250, 250), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(1200, 250), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(150, 350), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(450, 450), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(500, 550),  new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(600, 150), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(1150, 550), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(800, 550), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(1280/2, 820), new Vector2(1f, 1f), 0, 30f, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(1280 / 2 +(1280/4), 760), new Vector2(1f, 1f), 0, 30f, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(1400, 450), new Vector2(1f, 1f), 0, 30f, new Vector2(-1, 0)));

            lasers.Add(new Limit("Textures/Laser/Horizontal/VallaLaser0.png", new Vector2(1280/2, 715), new Vector2(1f, 1f), 0));
            lasers.Add(new Limit("Textures/Laser/Horizontal/VallaLaser0.png", new Vector2(1280 / 2, 5), new Vector2(1f, 1f), 0));

            lasersV.Add(new LimitVertical("Textures/Laser/VallaLaser0.png", new Vector2(5, 720/2), new Vector2(1f, 1f), 0));
            lasersV.Add(new LimitVertical("Textures/Laser/VallaLaser0.png", new Vector2(1275, 720/2), new Vector2(1f, 1f), 0));
        }
        public static void Reset()
        {
            _time = new Time();

            _player = new Character("Textures/Player/0NaveTop.png", new Vector2(1280 / 2, 720 / 2), new Vector2(0.75f, 0.75f), 0, 100f, new Vector2(0, -1), 1);

            enemies = new List<Enemy>();
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(150, 150), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(900, 200), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(250, 250), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(1200, 250), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(150, 350), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(450, 450), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(500, 550), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(600, 150), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(1150, 550), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(800, 550), new Vector2(1f, 1f), 0, 0, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(1280 / 2, 820), new Vector2(1f, 1f), 0, 30f, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(1280 / 2 + (1280 / 4), 760), new Vector2(1f, 1f), 0, 30f, new Vector2(0, -1)));
            enemies.Add(new Enemy("Textures/Asteroid/Asteroid0.png", new Vector2(1400, 450), new Vector2(1f, 1f), 0, 30f, new Vector2(-1, 0)));

            lasers = new List<Limit>();
            lasers.Add(new Limit("Textures/Laser/Horizontal/VallaLaser0.png", new Vector2(1280 / 2, 715), new Vector2(1f, 1f), 0));
            lasers.Add(new Limit("Textures/Laser/Horizontal/VallaLaser0.png", new Vector2(1280 / 2, 5), new Vector2(1f, 1f), 0));

            lasersV = new List<LimitVertical>();
            lasersV.Add(new LimitVertical("Textures/Laser/VallaLaser0.png", new Vector2(5, 720 / 2), new Vector2(1f, 1f), 0));
            lasersV.Add(new LimitVertical("Textures/Laser/VallaLaser0.png", new Vector2(1275, 720 / 2), new Vector2(1f, 1f), 0));

            GameManager.Instance.running = false;
        }
        public static void Update()
        {
            _player.Update();
            
            foreach (Enemy enemy in enemies) enemy.Update();
            foreach (Limit laser in lasers) laser.Update();
            foreach (LimitVertical laser in lasersV) laser.Update();

            _time.Update();
        }
        public static void Render()
        {
            Engine.Clear();
            Engine.Draw("Textures/Background/FondoEspacial.png");

            _player.Render();

            foreach (Enemy enemy in enemies) enemy.Render();
            foreach (Limit laser in lasers) laser.Render();
            foreach (LimitVertical laser in lasersV) laser.Render();

            Engine.Show();
        }
    }
}
