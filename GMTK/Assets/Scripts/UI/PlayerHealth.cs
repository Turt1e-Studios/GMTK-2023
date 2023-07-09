using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private Score scoreScript;
    private int _health;
    
    // Start is called before the first frame update
    void Start()
    {
        _health = 3;
    }

    public void LoseHealth()
    {
        _health--;
        Destroy(gameObject.transform.GetChild(_health).gameObject);
        if (_health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverScreen.Setup(scoreScript.score);
    }
}
