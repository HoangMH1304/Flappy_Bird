using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHandler : MonoBehaviour
{
    
    [SerializeField]
    private Text scoreTextInGame;
    [SerializeField]
    private Text scoreTextResult;
    [SerializeField]
    private GameObject gameoverCanvas;
    

    public void SetScoreText(int score)
    {
        scoreTextInGame.text = score.ToString();
        scoreTextResult.text = score.ToString();
    }

    public void ShowResultPanel()
    {
        gameoverCanvas?.SetActive(true);
    }
}
