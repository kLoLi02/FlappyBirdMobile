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


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bird")
        {
            Score.score++;
            pointAudio.Play();
        }
    }
}
