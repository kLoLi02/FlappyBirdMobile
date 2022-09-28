using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    [SerializeField] float delayToSpawn;
    [SerializeField] float height = 1f;

    float time = 0;

    void Update()
    {
        if (time > delayToSpawn)
        {
            CreatePipe();
            time = 0;
        }
        time += Time.deltaTime;
    }

    void CreatePipe()
    {
        var randomHeight = transform.position.y + Random.Range(-height, height);
        Instantiate(pipe, new Vector2(transform.position.x, randomHeight), Quaternion.identity);
    }
}
