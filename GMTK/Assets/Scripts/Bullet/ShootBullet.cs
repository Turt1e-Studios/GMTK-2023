using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletMultiplier;
    [SerializeField] private float cooldown;
    [SerializeField] private bool isInSameDirection;
    [SerializeField] private bool isHoming;

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
        else if (!isHoming)
        {
            bullet.GetComponent<MoveForward>().Velocity = Random.insideUnitCircle.normalized * bulletMultiplier;
        }
        else
        {
            bullet.GetComponent<Homing>().SpeedMultiplier = bulletMultiplier;
            Debug.Log(bullet.GetComponent<Homing>().SpeedMultiplier);
        }
    }
}
