using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private const float existTime = 5f;
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private float time = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(GameManager.Instance.IsGameOver()) return;
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if(time >= existTime)
        {
            time = 0;
            Destroy(gameObject);    
        }
        time += Time.deltaTime;
    }
}
