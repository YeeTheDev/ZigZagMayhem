using UnityEngine;
using System;

public class Shooter : MonoBehaviour
{
    public event Action onShoot;

    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] Transform muzzle = null;
    [SerializeField] float bulletSpeed = 3;
    [SerializeField] ParticleSystem muzzleDust = null;

    AudioSource audioSource;
    BulletPooler pooler;

    private void Awake()
    {
        pooler = GetComponent<BulletPooler>();
        audioSource = GetComponent<AudioSource>();
    }

    //Called in TankController
    public void Shoot()
    {
        GameObject bullet = pooler.GetObject();

        if (bullet == null) { return; }

        if (onShoot != null) { onShoot(); }

        bullet.transform.rotation = Quaternion.Euler(CalculateBulletInitialRotation());
        bullet.transform.position = muzzle.position;
        bullet.SetActive(true);
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;

        audioSource.Play();
        muzzleDust.Play();
    }

    private Vector3 CalculateBulletInitialRotation()
    {
        Vector3 bulletRotation = bulletPrefab.transform.eulerAngles;
        bulletRotation.y = muzzle.eulerAngles.y;

        return bulletRotation;
    }
}
