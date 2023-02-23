using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiHandler : MonoBehaviour
{
    private const string COLUMN = "Column";
    [SerializeField] private GameObject startGameUI;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private Score score;

    public void HandleStartGameUI()
    {
        score.SetScoreState(true);    
        startGameUI.SetActive(false);   
    }
    public void HandleGameOverUI()
    {
        endGameUI.SetActive(true);  
        score.SetScoreState(false);     
    }

    public void OnPlayBtnPressed()
    {
        SoundManager.Instance.PlaySound(SoundManager.Sound.swoosh);
        ObjectPool.Instance.SetObjectPoolState(false, COLUMN);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // GameManager.Instance.ChangeState(GameState.Standby);
    }
}
