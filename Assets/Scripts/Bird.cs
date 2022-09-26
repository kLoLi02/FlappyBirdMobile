using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float velocity;

    Rigidbody2D rb;
    State state;

    enum State
    {
        WaitingToStart,
        Playing
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.WaitingToStart;
        rb.isKinematic = true;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && state == State.WaitingToStart)
        {
            rb.velocity = Vector2.up * velocity;
            rb.isKinematic = false;
            state = State.Playing;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && state == State.Playing)
        {
            rb.velocity = Vector2.up * velocity;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Debug.Log("Bird is Dead");
    }
}
