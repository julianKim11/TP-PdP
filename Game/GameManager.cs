using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum GameState
    {
        MainMenu,
        GameOverScreen,
        WinScreen,
        Level
    }
    public class GameManager
    {
        private static GameManager instance;
        public const string GAMEOVER_PATH = "Textures/Background/GameOverFondoEspacial.png";
        public const string MAINMENU_PATH = "Textures/Background/GameOverFondoEspacial.png";
        public const string WIN_PATH = "Textures/Background/GameOverFondoEspacial.png";
        
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }
        public GameState CurrentState { get; private set; }
        public void Start()
        {
            ChangeGameState(GameState.MainMenu);
        }
        public void Update()
        {
            if (Engine.GetKey(Keys.SPACE))
            {
                ChangeGameState(GameState.Level);
            }
        }
        public void Render()
        {
            Engine.Clear(); 
            switch (CurrentState)
            {
                case GameState.MainMenu:
                    Engine.Draw(MAINMENU_PATH,0,0);
                    break;
                case GameState.GameOverScreen:
                    Engine.Draw(GAMEOVER_PATH, 0, 0);
                    break;
                case GameState.WinScreen:
                    Engine.Draw(WIN_PATH, 0, 0);
                    break;
                case GameState.Level:
                    Program.Render();
                    break;
            }
            Engine.Show();
        }

        public void ChangeGameState(GameState newState)
        {
            CurrentState = newState;
        }
    }
}
