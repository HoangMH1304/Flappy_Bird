using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string COLUMN = "Column";
    [SerializeField]
    private GameObject gameoverCanvas;
    [SerializeField]
    private GameObject getReady;
    [SerializeField]
    private Score score;
    private static bool gameOver;
    private static bool gameHasStarted;

   
    private void Start() {
        gameOver = false;
        gameHasStarted = false;
    }

    public void GameOver()
    {
        gameOver = true;
        gameoverCanvas.SetActive(true);
        score.SetScoreState(false);
    }

    public void StartGame()
    {
        gameHasStarted = true;
        score.SetScoreState(true);
        getReady.SetActive(false);
    }

    public static bool IsGameOver()
    {
        return gameOver;
    }

    public static bool HasGameStarted()
    {
        return gameHasStarted;
    }

    public void OnPlayBtnPressed()
    {
        SoundManager.Instance.PlaySound(SoundManager.Sound.swoosh);
        ObjectPool.Instance.SetObjectPoolState(false, COLUMN);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
