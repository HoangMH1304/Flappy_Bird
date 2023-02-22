using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private const float SPAWN_TIME = 1.5f;
    private const float MIN_HEIGHT = -1f;
    private const float MAX_HEIGHT = 3f;
    private const string COLUMN = "Column";
    [SerializeField]
    private GameObject pipe;
    private float time = 0;
    private Vector3 spawnPosition;

    private void Update() {
        if(!GameManager.IsGameOver() && GameManager.HasGameStarted())
        {
            if(time >= SPAWN_TIME)
            {
                Spawn();
                time = 0;
            }
            time += Time.deltaTime;
        }
    }

    private void Spawn()
    {
        GameObject go = ObjectPool.Instance.Spawn(COLUMN);
        float random = Random.Range(MIN_HEIGHT, MAX_HEIGHT);
        go.transform.position = transform.position;
        go.transform.position += Vector3.up * random;
        go.transform.SetParent(transform);
    }
}
