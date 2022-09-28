using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverDisplay;
    
    PipeSpawner pipeSpawner;
    IdleMovement idleMovement;
    SpriteScroller[] spriteScrollers;
    MainDisplay mainDisplay;
    Score score;

    void Awake()
    {
        pipeSpawner = FindObjectOfType<PipeSpawner>();
        idleMovement = FindObjectOfType<IdleMovement>();
        spriteScrollers = FindObjectsOfType<SpriteScroller>();
        mainDisplay = FindObjectOfType<MainDisplay>();
        score = FindObjectOfType<Score>();
    }

    void Start()
    {
        gameOverDisplay.SetActive(false);
        pipeSpawner.enabled = false;
        score.gameObject.SetActive(false);
    }

    public void StartProcess()
    {
        mainDisplay.MainDisplayStartProcess();
        pipeSpawner.enabled = true;
        idleMovement.enabled = false;
        score.gameObject.SetActive(true);
    }

    public void GameOverProcess()
    {
        pipeSpawner.enabled = false;
        gameOverDisplay.SetActive(true);
        Move.speed = 0;

        foreach (var spriteScroller in spriteScrollers)
        {
            spriteScroller.enabled = false;
        }
    }
}
