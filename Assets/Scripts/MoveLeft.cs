using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private BoxCollider2D box;
    private float groundWidth;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        groundWidth = box.size.x;
    }

    void Update()
    {
        if(GameManager.IsGameOver()) return;
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        if(transform.position.x <= -groundWidth)
        {
            transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);
        }
    }
}
