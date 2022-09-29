using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    AudioSource pointAudio;

    void Start()
    {
        pointAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bird"))
        {
            Score.score++;
            pointAudio.Play();
        }
    }
}
