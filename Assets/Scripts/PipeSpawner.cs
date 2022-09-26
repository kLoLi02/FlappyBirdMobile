using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    [SerializeField] float delayToSpawn;

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
        Instantiate(pipe, transform.position, Quaternion.identity);
    }

    void CreatePipe(float height, float xPosition)
    {
        Instantiate(pipe, transform.position, Quaternion.identity);
    }
}
