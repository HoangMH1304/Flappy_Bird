using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private const float EXIST_TIME = 5f;
    [SerializeField]
    private float speed;
    private float time = 0;

    private void OnEnable() 
    {
        time = 0;
    }

    private void Update() {
        if(GameManager.IsGameOver()) return;
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if(time >= EXIST_TIME)
        {
            time = 0;
            gameObject.SetActive(false);    
        }
        time += Time.deltaTime;
    }
}
