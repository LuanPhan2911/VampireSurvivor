using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }



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
    public enum GameState
    {
        GamePlaying,
        GamePause,
        GameOver,
    }
    public GameState gameState;
    public bool isGamePaused;
    public class OnGameStateChangedEventArgs : EventArgs
    {
        public GameState gameState;
    }
    public event EventHandler<OnGameStateChangedEventArgs> OnGameStateChanged;

    private void Update()
    {

        CheckGamePauseAndResume();
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
        isGamePaused = true;
        SetGameState(GameState.GamePause);
        PlayerManager.Instance.playerMovement.enabled = false;
        Time.timeScale = 0;

    }
    public void ResumeGame()
    {
        isGamePaused = false;
        SetGameState(GameState.GamePlaying);
        PlayerManager.Instance.playerMovement.enabled = true;
        Time.timeScale = 1f;
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
}
