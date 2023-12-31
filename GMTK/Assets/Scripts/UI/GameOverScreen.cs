using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI currentPointsText;
    [SerializeField] private GameObject audioManager;

    public bool IsGameOver { get; private set; }

    public void Setup(int score)
    {
        if (IsGameOver)
        {
            return;
        }
        IsGameOver = true;
        
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        gameObject.SetActive(true);
        pointsText.text = "SCORE: " + score;
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
        
        // set current score text to not be active
        currentPointsText.enabled = false;

        // SFX
        FindObjectOfType<AudioManager>().Play("GameOver");
        
        // Disable audio when game over
        audioManager.SetActive(false);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
