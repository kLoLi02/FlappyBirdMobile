using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float velocity;

    GameManager gameManager;
    Rigidbody2D rb;

    State state;
    bool isDead = false;

    enum State
    {
        WaitingToStart,
        Playing
    }

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        state = State.WaitingToStart;
        rb.isKinematic = true;
    }

    void Update()
    {
        if (isDead) { return; }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && state == State.WaitingToStart)
        {
            state = State.Playing;
            rb.velocity = Vector2.up * velocity;

            rb.isKinematic = false;

            gameManager.StartProcess();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && state == State.Playing)
        {
            rb.velocity = Vector2.up * velocity;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DiyProcess();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            DiyProcess();
        }
    }

    void DiyProcess()
    {
        gameManager.GameOverProcess();
        isDead = true;
        GetComponent<Animator>().SetTrigger("Dead");
    }
}
