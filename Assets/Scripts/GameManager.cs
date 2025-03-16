using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }




    public enum GameState
    {
        GamePlaying,
        GamePause,
        GameOver,
        PlayerLevelUp
    }
    public GameState gameState;
    public bool isGamePaused;
    public class OnGameStateChangedEventArgs : EventArgs
    {
        public GameState gameState;
    }
    public event EventHandler<OnGameStateChangedEventArgs> OnGameStateChanged;

    [Header("Stopwatch")]
    [SerializeField] private float survivalTimerLimit;
    public float survivalTime { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {

        CheckGamePauseAndResume();
        switch (gameState)
        {
            case GameState.GamePlaying:
                UpdateSurvialTime();
                break;
        }
    }

    public void SetGameState(GameState state)
    {
        gameState = state;
        OnGameStateChanged(this, new OnGameStateChangedEventArgs
        {
            gameState = state
        });
    }
    public void PauseGame()
    {
        if (gameState == GameState.GamePlaying)
        {
            isGamePaused = true;
            SetGameState(GameState.GamePause);
            PlayerManager.Instance.playerMovement.enabled = false;
            Time.timeScale = 0;
        }

    }
    public void ResumeGame()
    {
        if (gameState == GameState.GamePause)
        {
            isGamePaused = false;
            SetGameState(GameState.GamePlaying);
            PlayerManager.Instance.playerMovement.enabled = true;
            Time.timeScale = 1f;
        }
    }
    private void CheckGamePauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {

                ResumeGame();
            }
            else
            {

                PauseGame();
            }
        }
    }
    public void GameOver()
    {
        SetGameState(GameState.GameOver);
        Time.timeScale = 0;
        PlayerManager.Instance.playerMovement.enabled = false;
    }

    private void UpdateSurvialTime()
    {
        survivalTime += Time.deltaTime;
        if (survivalTime > survivalTimerLimit)
        {
            GameOver();
        }
    }

    public string GetStopWatchTimeString()
    {
        int minute = (int)survivalTime / 60;
        int second = (int)survivalTime % 60;
        return string.Format("{0:00}:{1:00}", minute, second);
    }
    public void StartPlayerLevelUp()
    {
        SetGameState(GameState.PlayerLevelUp);
        Time.timeScale = 0;
    }
    public void EndPlayerLevelUp()
    {
        SetGameState(GameState.GamePlaying);
        Time.timeScale = 1f;
    }
}
