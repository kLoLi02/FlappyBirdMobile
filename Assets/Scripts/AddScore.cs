using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    AudioSource pointAudio;
    UIDisplay UIDisplay;

    void Start()
    {
        UIDisplay = FindObjectOfType<UIDisplay>();
        pointAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bird"))
        {
            UIDisplay.UpdateScore();
            pointAudio.Play();
        }
    }
}
