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
        public StaticScreen GameOverScreen = new StaticScreen("Textures/Background/GameOverFondoEspacial.png");
        public StaticScreen MainMenuScreen = new StaticScreen("Textures/Background/MainMenuFondoEspacial.png");
        public StaticScreen WinScreen = new StaticScreen("Textures/Background/WinScreenFondoEspacial.png");
        public LevelController LevelController { get; private set; }
        
        private static GameManager instance;

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
        public bool running = false;
        public void Start()
        {
            LevelController = new LevelController();
            LevelController.Start();
            ChangeGameState(GameState.MainMenu);
        }
        public void Update()
        {
            LevelController.Update();

            if (Engine.GetKey(Keys.SPACE))
            {
                if (CurrentState == GameState.MainMenu)
                {
                    GameManager.Instance.ChangeGameState(GameState.Level);
                    running = true;
                }
            }         
            if (Engine.GetKey(Keys.ESCAPE))
            {
                if (CurrentState == GameState.GameOverScreen)
                {
                    GameManager.Instance.ChangeGameState(GameState.MainMenu);
                }
                if (CurrentState == GameState.WinScreen)
                {
                    GameManager.Instance.ChangeGameState(GameState.MainMenu);
                }
            }
        } 
        public void Render()
        {
            Engine.Clear();
            switch (CurrentState)
            {
                case GameState.MainMenu:
                    MainMenuScreen.Render();
                    break;
                case GameState.GameOverScreen:
                    GameOverScreen.Render();
                    break;
                case GameState.WinScreen:
                    WinScreen.Render();
                    break;
                case GameState.Level:
                    LevelController.Render();
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