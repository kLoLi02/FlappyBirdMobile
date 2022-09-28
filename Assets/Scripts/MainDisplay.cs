using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDisplay : MonoBehaviour
{
    [SerializeField] Animator flappybirdImageAimator;
    [SerializeField] GameObject tapImage;

    void Start()
    {
        flappybirdImageAimator.enabled = false; 
    }

    public void MainDisplayStartProcess()
    {
        flappybirdImageAimator.enabled = true;
        tapImage.SetActive(false);
    }
}
