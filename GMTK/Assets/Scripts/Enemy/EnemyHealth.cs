using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int pointsWorth;
    [SerializeField] private AudioClip hitSound;

    private AudioSource _audioSource;
    private int _health;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _health = maxHealth;
    }

    public void TakeDamage()
    {
        Invoke(nameof(PlaySound), 0.1f);
        _health--;
        if (_health <= 0)
        {
            GameObject.Find("Score").GetComponent<Score>().ChangeScore(pointsWorth);
            Destroy(gameObject);
        }
    }

    // Audio not working
    private void PlaySound()
    {
        _audioSource.PlayOneShot(hitSound, 1.0f);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet") && col.gameObject.GetComponent<Reflection>().hasReflected)
        {
            TakeDamage();
            Destroy(col.gameObject);
        }
        
        if (col.gameObject.CompareTag("Player"))
        {
            TakeDamage();
        }
    }
}
