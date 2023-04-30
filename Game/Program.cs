using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {

        private static DateTime startTime;
        private static float lastFrame;
        public static float deltaTime;

        private static Player player = new Player("Textures/Player/NaveTop.png", 200, 100, 1f, 1f, 90, 32, 32);

        static void Main(string[] args)
        {
            Engine.Initialize("Game", 1280, 720);

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
            player.Update();
            DeltaTimeCalculation();
            
        }
        private static void Render()
        {
            Engine.Clear();
            Engine.Draw("Textures/Background/FondoEspacial.png");
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