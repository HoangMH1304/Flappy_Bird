using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const int MIN_ANGLE = -90;
    private const int MAX_ANGLE = 20;
    [SerializeField]
    private float force = 4f;
    private Rigidbody2D rb;
    private int angle = 0;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void Update()
    {
        if(GameManager.Instance.IsGameOver()) return;
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Jump();
            }
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
        SoundManager.PlaySound(SoundManager.Sound.wing);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Hoang");
            GameManager.Instance.GameOver();
            SoundManager.PlaySound(SoundManager.Sound.hit);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Pass"))
        {
            GameManager.Instance.IncreaseScore();
            SoundManager.PlaySound(SoundManager.Sound.point);
        }
    }

}
