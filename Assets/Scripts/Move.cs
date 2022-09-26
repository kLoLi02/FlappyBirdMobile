using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speedMove;

    void Update()
    {
        transform.position += Vector3.left * speedMove * Time.deltaTime;
    }
}
