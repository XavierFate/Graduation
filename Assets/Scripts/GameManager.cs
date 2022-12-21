using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public InterstitialAds Ad;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public GameObject startScreen;
        [SerializeField] private GameObject gameScreen;

        public enum GameState
        {
            None,
            Start,
            Game
        }

        private GameState _state;

        public GameState State
        {
            get => _state;
            set
            {
                if (value == _state)
                    return;

                _state = value;
                GameObject screen = null;
                switch (_state)
                {
                    case GameState.Start:
                        screen = startScreen;
                        break;
                    case GameState.Game:
                        screen = gameScreen;
                        break;
                }

                OpenScreen(screen);
            }
        }

        private GameObject _currentScreen;

        #region UI Logic

        private void OpenScreen(GameObject screen)
        {
            if (_currentScreen)
            {
                _currentScreen.SetActive(false);
            }

            _currentScreen = screen;
            _currentScreen.SetActive(true);
        }

        #endregion

        private void Start()
        {
            TurnOffAllScreens();
            State = GameState.Start;
            Time.timeScale = 0f;
        }

        private void TurnOffAllScreens()
        {
            startScreen.SetActive(false);
            gameScreen.SetActive(false);
        }

        public void StartGame()
        {
            State = GameState.Game;
            Time.timeScale = 1f;
        }
        public void RestartGame()
        {
            StartGame();
        }
    }
}