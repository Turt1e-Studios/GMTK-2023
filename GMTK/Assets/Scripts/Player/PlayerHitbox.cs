using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            FindObjectOfType<AudioManager>().Play("TakingDamage");
            ui.GetComponent<PlayerHealth>().LoseHealth();
            Destroy(col.gameObject);
        }
    }
}
