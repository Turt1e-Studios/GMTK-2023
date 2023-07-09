using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletMultiplier;
    [SerializeField] private float cooldown;
    [SerializeField] private bool isInSameDirection;

    private void Start()
    {
        InvokeRepeating(nameof(Shoot), 0.1f, cooldown);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        if (isInSameDirection)
        {
            bullet.GetComponent<MoveForward>().Velocity = GetComponent<CharacterMovement>().Direction * bulletMultiplier;
        }
        else
        {
            bullet.GetComponent<MoveForward>().Velocity = Random.insideUnitCircle.normalized * bulletMultiplier;
        }
    }
}
