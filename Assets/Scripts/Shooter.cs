using UnityEngine;
using System;

public class Shooter : MonoBehaviour
{
    public event Action onShoot;

    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] Transform muzzle = null;
    [SerializeField] float bulletSpeed = 3;
    [SerializeField] ParticleSystem muzzleDust = null;
    [SerializeField] string shootParameter = "Shoot";

    bool finishedShooting = true;
    GameObject bulletToUse;
    Animator animator;
    AudioSource audioSource;
    BulletPooler pooler;

    private void Awake()
    {
        pooler = GetComponent<BulletPooler>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    //Called in TankController
    public void CheckIfCanShoot()
    {
        if (!finishedShooting) { return; }

        bulletToUse = pooler.GetObject();

        if (bulletToUse == null) { return; }

        finishedShooting = false;
        animator.SetTrigger(shootParameter);
    }

    //Called in Animation
    private void Shoot()
    {
        if (onShoot != null) { onShoot(); }

        bulletToUse.transform.rotation = Quaternion.Euler(CalculateBulletInitialRotation());
        bulletToUse.transform.position = muzzle.position;
        bulletToUse.SetActive(true);
        bulletToUse.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;

        audioSource.Play();
        muzzleDust.Play();

        finishedShooting = true;
    }

    private Vector3 CalculateBulletInitialRotation()
    {
        Vector3 bulletRotation = bulletPrefab.transform.eulerAngles;
        bulletRotation.y = muzzle.eulerAngles.y;

        return bulletRotation;
    }
}
