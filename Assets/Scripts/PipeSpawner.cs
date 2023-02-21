using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private const float SPAWN_TIME = 1.5f;
    private const float MIN_HEIGHT = -1f;
    private const float MAX_HEIGHT = 3f;
    [SerializeField]
    private GameObject pipe;
    private float time = 0;
    private Vector3 spawnPosition;

    // private void OnEnable() {
    //     InvokeRepeating(nameof(Spawn), SPAWN_TIME, SPAWN_TIME);
    // }
    // private void OnDisable() {
    //     CancelInvoke(nameof(Spawn));
    // }

    private void Update() {
        if(GameManager.Instance.IsGameOver()) return;
        if(time >= SPAWN_TIME)
        {
            Spawn();
            time = 0;
        }
        time += Time.deltaTime;
    }

    private void Spawn()
    {
        GameObject go = Instantiate(pipe, transform.position, Quaternion.identity);
        float random = Random.Range(MIN_HEIGHT, MAX_HEIGHT);
        go.transform.position += Vector3.up * random;
        go.transform.SetParent(transform);
    }

}
