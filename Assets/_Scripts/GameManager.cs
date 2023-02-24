using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Standby,
    StartGame,
    EndGame
}
public class GameManager : MonoSingleton<GameManager>
{
    public GameState State {get; private set;}
    private bool gameStart;
    private bool gameOver;
    public bool GameStart { get => gameStart; set => gameStart = value; }
    public bool GameOver { get => gameOver; set => gameOver = value; }


    public void ChangeState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.Standby:
                HandleStandbyState();
                Debug.Log((newState));
                break;
            case GameState.StartGame:
                HandleStartGameState();
                Debug.Log((newState));
                break;
            case GameState.EndGame:
                HandleEndGameState();
                Debug.Log((newState));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    public void HandleStandbyState()
    {
        gameStart = false;
        gameOver = false;
    }

    public void HandleStartGameState()
    {
        gameStart = true;
    }

    public void HandleEndGameState()
    {
        gameOver = true;
    }
}
