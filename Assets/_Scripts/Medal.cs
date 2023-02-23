using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private Sprite normalMedal;
    [SerializeField] private Sprite bronzeMedal;
    [SerializeField] private Sprite silverMedal;
    [SerializeField] private Sprite goldMedal;
    private Image image;

    private void Start() {
        image = GetComponent<Image>();
        int gameScore = score.GetScore();

        if(gameScore > 0 && gameScore <= 2)
        {
            image.sprite = normalMedal;
        }
        else if(gameScore > 2 && gameScore <= 4)
        {
            image.sprite = bronzeMedal;
        }
        else if (gameScore > 4 && gameScore <= 6)
        {
            image.sprite = silverMedal;
        }
        else if (gameScore > 6)
        {
            image.sprite = goldMedal;
        }
    }
}
