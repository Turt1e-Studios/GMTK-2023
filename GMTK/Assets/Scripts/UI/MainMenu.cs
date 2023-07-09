using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }

    public void EasyDifficulty()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        PlayGame();
    }
    
    public void MediumDifficulty()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
        PlayGame();
    }
    
    public void DifficultDifficulty()
    {
        PlayerPrefs.SetInt("Difficulty", 3);
        PlayGame();
    }
}
