using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameOverDisplay gameOverDisplay;
    PipeSpawner pipeSpawner;
    IdleMovement idleMovement;
    SpriteScroller[] spriteScrollers;
    MainDisplay mainDisplay;
    Score score;

    void Awake()
    {
        gameOverDisplay = FindObjectOfType<GameOverDisplay>();
        pipeSpawner = FindObjectOfType<PipeSpawner>();
        idleMovement = FindObjectOfType<IdleMovement>();
        spriteScrollers = FindObjectsOfType<SpriteScroller>();
        mainDisplay = FindObjectOfType<MainDisplay>();
        score = FindObjectOfType<Score>();
    }

    void Start()
    {
        gameOverDisplay.gameObject.SetActive(false);
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
        gameOverDisplay.gameObject.SetActive(true);
        Move.speed = 0;

        foreach (var spriteScroller in spriteScrollers)
        {
            spriteScroller.enabled = false;
        }
    }
}
