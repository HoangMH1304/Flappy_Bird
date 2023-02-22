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

    private void Start() {
        score = 0;
        scoreText.text = score.ToString();
        scoreInPanel.text = score.ToString();
        highScore = PlayerPrefs.GetInt("highscore");
        highScoreInPanel.text = highScore.ToString();
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
        scoreInPanel.text = score.ToString();
        newRecord.SetActive(false);
        if(score > highScore)
        {
            highScore = score;
            highScoreInPanel.text = highScore.ToString();
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
