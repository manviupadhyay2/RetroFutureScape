using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level3_Scoring : MonoBehaviour
{

    private int playerScore = 0;
    public TextMeshProUGUI scoreText;
    private float scoreCooldown = 1.0f; // Cooldown duration in seconds
    private float lastScoreTime = 0.0f; // Time when the score was last incremented

    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScore(int points)
    {
        // Check if enough time has passed since the last score increment
        if (Time.time - lastScoreTime >= scoreCooldown)
        {
            playerScore += points;
            UpdateScoreText();
            lastScoreTime = Time.time; // Record the time of the score increment
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + playerScore.ToString();
        }
    }
}
