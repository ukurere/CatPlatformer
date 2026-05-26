using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int currentScore = 0;
    private int highScore = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        UIManager ui = FindAnyObjectByType<UIManager>();
        if (ui != null) ui.UpdateScore(currentScore, highScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    public int GetScore() => currentScore;
    public int GetHighScore() => highScore;
}