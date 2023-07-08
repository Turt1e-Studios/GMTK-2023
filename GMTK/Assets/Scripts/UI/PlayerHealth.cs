using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health;
    
    // Start is called before the first frame update
    void Start()
    {
        _health = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoseHealth()
    {
        _health--;
        if (_health <= 0)
        {
            // game over
        }
        Destroy(gameObject.transform.GetChild(_health).gameObject);
    }
}
