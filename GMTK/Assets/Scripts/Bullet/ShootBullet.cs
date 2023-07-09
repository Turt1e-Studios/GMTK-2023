using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float timeUntilBeginShoot;
    [SerializeField] private float bulletMultiplier;
    [SerializeField] private float cooldown;
    [SerializeField] private bool isInSameDirection;
    [SerializeField] private bool isHoming;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Character");
        InvokeRepeating(nameof(Shoot), timeUntilBeginShoot, cooldown);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        if (isInSameDirection)
        {
            bullet.GetComponent<MoveForward>().Velocity = GetComponent<CharacterMovement>().Direction * bulletMultiplier;
        }
        else if (!isHoming)
        {
            bullet.GetComponent<MoveForward>().Velocity = (player.transform.position - transform.position).normalized * bulletMultiplier;
        }
        else
        {
            bullet.GetComponent<Homing>().SpeedMultiplier = bulletMultiplier;
            Debug.Log(bullet.GetComponent<Homing>().SpeedMultiplier);
        }
    }
}
