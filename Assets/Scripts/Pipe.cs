using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
        Destroy(gameObject, 8f);
    }

    private void OnEnable() {
        // Debug.Log("start");
        // Debug.Log(transform.position);
    }

    private void OnDisable() {
        // Debug.Log("end");
    }
}
