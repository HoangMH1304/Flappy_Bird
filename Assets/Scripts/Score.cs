using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    private int highScore = 0;
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text scoreInPanel;
    [SerializeField]
    private Text highScoreInPanel;
    [SerializeField]
    private GameObject newRecord;

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
        scoreText.text = score.ToString();
        scoreInPanel.text = score.ToString();
        highScoreInPanel.text = highScore.ToString();
    }
    public void UpdateScore()
    {
        score++;
        newRecord.SetActive(false);
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
        scoreText.gameObject.SetActive(state);
    }

    public int GetScore()
    {
        return score;
    }
}
