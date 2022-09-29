using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float velocity;
    [SerializeField] float rotationRegulation = 10f;

    [Header("Sounds")]
    [SerializeField] AudioClip hitClip;
    [SerializeField] AudioClip wingClip;

    GameManager gameManager;
    AudioSource audioSource;
    Rigidbody2D rb;

    State state;
    bool isDead = false;

    enum State
    {
        WaitingToStart,
        Playing,
        Dying
    }

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
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


        switch (state)
        {
            case State.WaitingToStart:
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    state = State.Playing;

                    audioSource.PlayOneShot(wingClip);
                    rb.velocity = Vector2.up * velocity;

                    rb.isKinematic = false;

                    gameManager.StartProcess();
                }
                break;
            case State.Playing:
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    rb.velocity = Vector2.up * velocity;
                    audioSource.PlayOneShot(wingClip);
                }

                float rotationZ = Mathf.Clamp(rb.velocity.y * rotationRegulation, -45, 30);
                transform.eulerAngles = new Vector3(0, 0, rotationZ);

                break;
            case State.Dying:
                DyingProcess();
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            state = State.Dying;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        state = State.Dying;
    }

    void DyingProcess()
    {
        gameManager.GameOverProcess();
        isDead = true;
        GetComponent<Animator>().SetTrigger("Dead");
        audioSource.PlayOneShot(hitClip);
    }
}
