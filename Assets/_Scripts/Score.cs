using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour, IObserver
{
    [SerializeField] private Subject subject;
    [SerializeField] private Text scoreInGame;
    [SerializeField] private Text scoreInPanel;
    [SerializeField] private Text highScoreInPanel;
    [SerializeField] private GameObject newRecord;
    private int score;
    private int highScore = 0;

    private void OnEnable() 
    {
        subject.AddObserver(this);
    }

    private void OnDisable() 
    {
        subject.RemoveObserver(this);
    }
    private void Start()
    {
        InitScore();
        DisplayScoreUI();
    }

    private void InitScore()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("highscore");
    }

    private void DisplayScoreUI()
    {
        scoreInGame.text = score.ToString();
        scoreInPanel.text = score.ToString();
        highScoreInPanel.text = highScore.ToString();
    }
    public void UpdateScore()
    {
        score++;
        HighScoreSolve();
        DisplayScoreUI();
    }

    private void HighScoreSolve()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
            newRecord.SetActive(true);
        }
    }

    public void SetScoreState(bool state)
    {
        scoreInGame.gameObject.SetActive(state);
    }

    public int GetScore()
    {
        return score;
    }

    public void OnNotify(PlayerActions action)
    {
        switch (action)
        {
            case (PlayerActions.OnStart):
                InitScore();
                return;
            case (PlayerActions.OnPass):
                UpdateScore();
                return;
            case (PlayerActions.OnDeath):
                return;
            default:
                return;
        }
    }
}
