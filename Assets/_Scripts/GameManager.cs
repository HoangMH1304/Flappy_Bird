using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    Standby,
    StartGame,
    EndGame
}
public class GameManager : MonoBehaviour
{

    public GameState State {get; private set;}

    private static GameManager instance;
    public static GameManager Instance {get => instance;}

    private bool gameStart;
    private bool gameOver;
    public bool GameStart { get => gameStart; set => gameStart = value; }
    public bool GameOver { get => gameOver; set => gameOver = value; }

    private UiHandler uiHandler;


    private void Awake() {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // uiHandler = FindObjectOfType<UiHandler>();
        // Debug.Log($"uiHandler: {uiHandler}");
    }

    public void ChangeState(GameState newState)
    {
        uiHandler = FindObjectOfType<UiHandler>();
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
        uiHandler.HandleStartGameUI();
    }

    public void HandleEndGameState()
    {
        gameOver = true;
        uiHandler.HandleGameOverUI();
    }
}
