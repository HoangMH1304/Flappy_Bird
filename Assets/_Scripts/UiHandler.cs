using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiHandler : MonoBehaviour, IObserver
{
    private const string COLUMN = "Column";
    [SerializeField] private Subject subject;
    [SerializeField] private GameObject startGameUI;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private Score score;

    private void OnEnable() 
    {
        subject.AddObserver(this);
    }

    private void OnDisable() 
    {
        subject.RemoveObserver(this);
    }

    public void HandleStartGameUI()
    {
        score.SetScoreState(true);    
        startGameUI.SetActive(false);
        Logger.Log("Enter game");  
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
    }

    public void OnNotify(PlayerActions action)
    {
        switch (action)
        {
            case (PlayerActions.OnStart):
                HandleStartGameUI();
                return;
            case (PlayerActions.OnPass):
                return;
            case (PlayerActions.OnDeath):
                HandleGameOverUI();
                return;
            default:
                return;
        }
    }
}
