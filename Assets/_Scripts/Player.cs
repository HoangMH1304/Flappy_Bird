using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const int MIN_ANGLE = -90;
    private const int MAX_ANGLE = 20;
    private const string GROUND = "Ground";
    private const string PIPE = "Pipe";
    private const string COLUMN = "Column";
    [SerializeField]
    private float force = 4f;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private Score score;
    private Rigidbody2D rb;
    private int angle = 0;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void Update()
    {
        if(GameManager.IsGameOver()) return;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(!GameManager.HasGameStarted())
            {
                gameManager.StartGame();
            }
            Jump();
            SoundManager.Instance.PlaySound(SoundManager.Sound.wing);
        }
        RotateBird();
    }

    private void RotateBird()
    {
        if (rb.velocity.y > 0)
        {
            if (angle < MAX_ANGLE)
            {
                angle += 15;
            }
        }
        else if (rb.velocity.y < -1.2f)
        {
            if (angle > MIN_ANGLE)
            {
                angle -= 3;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * force;
        if(rb.gravityScale == 0) rb.gravityScale = 1.5f;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(GROUND) || other.gameObject.CompareTag(PIPE))
        {
            if(!GameManager.IsGameOver()) 
                SoundManager.Instance.PlaySound(SoundManager.Sound.hit);
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(COLUMN))
        {
            score.UpdateScore();
            SoundManager.Instance.PlaySound(SoundManager.Sound.point);
        }
    }
}
