using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] Transform muzzle = null;
    [SerializeField] float bulletSpeed = 3;

    //Called in TankController
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.Euler(CalculateBulletInitialRotation()));
        bullet.GetComponent<Rigidbody>().velocity = muzzle.up * bulletSpeed;
    }

    private Vector3 CalculateBulletInitialRotation()
    {
        Vector3 bulletRotation = bulletPrefab.transform.eulerAngles;
        bulletRotation.y = muzzle.eulerAngles.y;

        return bulletRotation;
    }
}
