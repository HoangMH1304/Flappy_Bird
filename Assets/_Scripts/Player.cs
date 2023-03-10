using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Subject
{
    private const int MIN_ANGLE = -90;
    private const int MAX_ANGLE = 20;
    private const string GROUND = "Ground";
    private const string PIPE = "Pipe";
    private const string COLUMN = "Column";
    [SerializeField] private float force = 4f;
    private int angle = 0;
    private Rigidbody2D rb;

    private void Start() 
    {
        GameManager.Instance.ChangeState(GameState.Standby);
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void Update()
    {
        if(GameManager.Instance.GameOver) return;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(!GameManager.Instance.GameStart)
            {
                GameManager.Instance.ChangeState(GameState.StartGame);
                NotifyObservers(PlayerActions.OnStart);
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
            NotifyObservers(PlayerActions.OnDeath);
            //
            GetComponent<Animator>().enabled = false;
            if(!GameManager.Instance.GameOver)
            {
                SoundManager.Instance.PlaySound(SoundManager.Sound.hit);
                GameManager.Instance.ChangeState(GameState.EndGame);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(COLUMN))
        {
            NotifyObservers(PlayerActions.OnPass);
            //
            SoundManager.Instance.PlaySound(SoundManager.Sound.point);
        }
    }
}
