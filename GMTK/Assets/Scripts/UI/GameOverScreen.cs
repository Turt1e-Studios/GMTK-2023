using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public GameObject music;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI currentPointsText;
    [SerializeField] private AudioClip gameOverSound;

    private AudioSource _playerAudio;
    private bool _isGameOver;

    private void Start()
    {
        _playerAudio = GetComponent<AudioSource>();
    }

    public void Setup(int score)
    {
        if (_isGameOver)
        {
            return;
        }
        _isGameOver = true;
        
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        gameObject.SetActive(true);
        pointsText.text = "SCORE: " + score;
        highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
        
        // set current score text to not be active
        currentPointsText.enabled = false;
        
        // disable music
        music.SetActive(false);
        
        // SFX
        _playerAudio.PlayOneShot(gameOverSound, 1.0f);
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
