using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        private const int width = 1280;
        private const int height = 720;

        static void Main(string[] args)
        {
            Engine.Initialize("Game", width, height);
            Start();

            while (true)
            {
                Update();
                GameManager.Instance.Update();
                GameManager.Instance.Render();
            }
        }

        private static void Start()
        {
            GameManager.Instance.Start();
        }

        private static void Update()
        {
            GameManager.Instance.Update();
        }

        public static void Render()
        {
            GameManager.Instance.Render();
        }
    }
}