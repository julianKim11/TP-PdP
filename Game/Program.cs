using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        /*public class Enemy
        {
            private float damage;

            public Enemy(float damage)
            {
                this.damage = damage;
            }
        }*/

        private static DateTime startTime;
        private static float lastFrame;
        public static float deltaTime;

        private static Player player = new Player("Textures/Player/NaveTop.png", 
                                       new Vector2(200, 100), new Vector2(1f, 1f), 
                                       90, new Vector2(32, 32));
        //private static List<Player> player;
        static void Main(string[] args)
        {
            Engine.Initialize("Game", 1280, 720);

            /*player = new List<Player>
            {
                new Player();
            }*/

            Start();

            while(true)
            {
                Update();
                Render();
            }
        }
        private static void Start()
        {
            Engine.Debug("Start");
            
            startTime = DateTime.Now;
        }
        private static void Update()
        {
            //foreach (Player c in player) c.Update;
            player.Update();
            DeltaTimeCalculation();
            
        }
        private static void Render()
        {
            Engine.Clear();
            Engine.Draw("Textures/Background/FondoEspacial.png");
            //foreach (Player c in player) c.Render;
            player.Render();
            Engine.Show();
        }
        private static void DeltaTimeCalculation()
        {
            float currentFrame = (float)(DateTime.Now - startTime).TotalSeconds;
            deltaTime = currentFrame - lastFrame;
            lastFrame = currentFrame;
        }
    }
}