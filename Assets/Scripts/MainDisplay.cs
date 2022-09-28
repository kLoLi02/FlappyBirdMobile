using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDisplay : MonoBehaviour
{
    [SerializeField] Animator flappyBirdTextAimator;
    [SerializeField] GameObject tapImage;

    void Start()
    {
        flappyBirdTextAimator.enabled = false; 
    }

    public void MainDisplayStartProcess()
    {
        flappyBirdTextAimator.enabled = true;
        tapImage.SetActive(false);
    }
}
