using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    public UnityEngine.UI.Text ScoreUser;

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void Restart()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreText()
    {
        // Update the UI Text component with the current score
        if (ScoreUser != null)
        {
            ScoreUser.text = score.ToString();
        }
    }
}