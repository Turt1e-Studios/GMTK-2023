using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int pointsWorth;
    private int _health;

    // Start is called before the first frame update
    void Start()
    {
        _health = maxHealth;
    }

    public void TakeDamage()
    {
        _health--;
        if (_health <= 0)
        {
            GameObject.Find("Score").GetComponent<Score>().ChangeScore(pointsWorth);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet") && col.gameObject.GetComponent<Reflection>().hasReflected)
        {
            TakeDamage();
            Destroy(col.gameObject);
        }
    }
}
