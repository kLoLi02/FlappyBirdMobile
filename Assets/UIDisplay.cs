using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] Animator flappyBirdTextAimator;
    [SerializeField] GameObject tapImage;

    [SerializeField] TextMeshProUGUI mainScoreText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject mainPanel;

    //public static int score = 0;
    int score = 0;

    string bestScoreKey = "BestScore";

    void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
        flappyBirdTextAimator.enabled = false;

        mainScoreText.text = score.ToString();
        mainScoreText.enabled = false;
    }

    void Update()
    {
        if (PlayerPrefs.HasKey(bestScoreKey))
        {
            if (score > PlayerPrefs.GetInt(bestScoreKey))
            {
                PlayerPrefs.SetInt(bestScoreKey, score);
            }
        }
        else
        {
            PlayerPrefs.SetInt(bestScoreKey, score);
        }
    }

    public void DisableMainPanel()
    {
        mainPanel.SetActive(false);
    }

    public void EnableGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        scoreText.text = "Score\n" + score.ToString();
        bestScoreText.text = "Best Score:\n" + PlayerPrefs.GetInt(bestScoreKey).ToString();
        mainScoreText.enabled = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void MainDisplayStartProcess()
    {
        flappyBirdTextAimator.enabled = true;
        tapImage.SetActive(false);
    }

    public void UpdateScore()
    {
        score++;
        mainScoreText.text = score.ToString();
        mainScoreText.enabled = true;
    }
}
