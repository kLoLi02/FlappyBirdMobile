using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIDisplay UIDisplay;
    PipeSpawner pipeSpawner;
    IdleMovement idleMovement;
    SpriteScroller[] spriteScrollers;

    void Awake()
    {
        UIDisplay = FindObjectOfType<UIDisplay>();
        pipeSpawner = FindObjectOfType<PipeSpawner>();
        idleMovement = FindObjectOfType<IdleMovement>();
        spriteScrollers = FindObjectsOfType<SpriteScroller>();
    }

    void Start()
    {
        pipeSpawner.enabled = false;
    }

    public void StartProcess()
    {
        UIDisplay.DisableMainPanel();
        pipeSpawner.enabled = true;
        idleMovement.enabled = false;
    }

    public void GameOverProcess()
    {
        UIDisplay.EnableGameOverPanel();

        pipeSpawner.enabled = false;
        Move.speed = 0;

        foreach (var spriteScroller in spriteScrollers)
        {
            spriteScroller.enabled = false;
        }
    }
}
