using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float _speed = 1;

    public static float speed = 1;

    void Start()
    {
        speed = _speed;
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
