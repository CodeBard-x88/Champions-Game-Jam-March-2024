using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float initialValue = 0f; 
    public float increaseRate = 1f; 

    private float currentScore; 
    public Text scoreText; 

    private void Start()
    {
        currentScore = initialValue; 
        UpdateScoreText(); 
        InvokeRepeating(nameof(IncreaseScore), 1f, 1f);
    }

    private void IncreaseScore()
    {
        currentScore += increaseRate; 
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
    }
}
