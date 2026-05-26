using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;

    public void UpdateHearts(int currentHealth, int maxHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i >= maxHealth)
            {
                hearts[i].gameObject.SetActive(false);
            }
            else
            {
                hearts[i].gameObject.SetActive(true);
                hearts[i].color = i < currentHealth ? Color.red : Color.gray;
            }
        }
    }

    public void UpdateScore(int score, int highScore)
    {
        if (scoreText != null) scoreText.text = "Fish: " + score;
        if (highScoreText != null) highScoreText.text = "Best: " + highScore;
    }
}