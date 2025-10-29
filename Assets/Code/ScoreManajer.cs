using UnityEngine;
using TMPro;

public class ScoreManajer : MonoBehaviour
{
    public static ScoreManajer Instance;
    public TMP_Text scoreText;
    private int score;
    private void Awake()
    {
        Instance = this;
        score = 0;
        UpdateScoreText();
    }
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
    public int GetScore()
    {
        return score;
    }
    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }
}
