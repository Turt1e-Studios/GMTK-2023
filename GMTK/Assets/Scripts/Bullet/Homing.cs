using System;
using Unity.VisualScripting;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public float SpeedMultiplier { get; set; }
    [SerializeField] private float speed;
    [SerializeField] private Sprite reflectedSprite;
    
    private GameObject _objectFollowing;
    private bool _hasReflected;
    
    // Start is called before the first frame update
    void Start()
    {
        _objectFollowing = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
        // if the object it was homing was already destroyed, then change targets
        if (_objectFollowing == null)
        {
            SelectTarget();
        }
        transform.Translate((_objectFollowing.transform.position - transform.position).normalized * (speed * SpeedMultiplier * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Shield"))
        {
            SelectTarget();
            _hasReflected = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = reflectedSprite;
            FindObjectOfType<AudioManager>().Play("Reflection");
        }
        // Once it's been reflected, it can also hit other enemies
        else if (col.gameObject.CompareTag("Enemy") && _hasReflected)
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage();
            Destroy(gameObject);
        }
    }

    private void SelectTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            return;
        }
        GameObject currentClosestEnemy = enemies[0];
        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) <
                Vector2.Distance(transform.position, currentClosestEnemy.transform.position))
            {
                currentClosestEnemy = enemy;
            }
        }
        // goes towards an enemy instead of being destroyed
        _objectFollowing = currentClosestEnemy;
    }
}
