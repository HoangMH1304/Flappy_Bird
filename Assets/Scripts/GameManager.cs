using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }
    [SerializeField]
    public SoundAudioClip[] soundAudioClips;

    [Serializable]
    public class SoundAudioClip{
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    private UiHandler uiHandler;

    // [SerializeField]
    // private Text scoreTextInGame;
    // [SerializeField]
    // private Text scoreTextResult;
    // [SerializeField]
    // private GameObject gameoverCanvas;
    private int score;
    private bool gameover;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        gameover = false;
        uiHandler = FindObjectOfType<UiHandler>();
    }

    public void IncreaseScore()
    {
        score++;
        // scoreTextInGame.text = score.ToString();
        // scoreTextResult.text = score.ToString();
        uiHandler.SetScoreText(score);
    }

    public void GameOver()
    {
        gameover = true;
        // gameoverCanvas.SetActive(true);
        uiHandler.ShowResultPanel();
    }

    public bool IsGameOver()
    {
        return gameover;
    }

    public void OnPlayBtnPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameover = false;
    }
}
