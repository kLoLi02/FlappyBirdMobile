using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    void OnCollisionEnter2D()
    {
        Score.score++;
    }
}
