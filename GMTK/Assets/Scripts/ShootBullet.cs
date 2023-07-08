using System;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
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
            bullet.GetComponent<MoveForward>().Velocity = GetComponent<CharacterMovement>().Direction;
        }
    }
}
