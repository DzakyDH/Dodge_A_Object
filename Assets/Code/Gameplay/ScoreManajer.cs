using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManajer : MonoBehaviour
{
    public static ScoreManajer Instance;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    private int score = 0;
    private int highScore = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        score = 0;
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            UpdateHighScoreText();
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    private void UpdateHighScoreText()
    {
        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
    }

    public int GetScore() => score;
    public int GetHighScore() => highScore;

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}