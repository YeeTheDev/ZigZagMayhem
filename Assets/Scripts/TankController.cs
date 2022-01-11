using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankMover))]
public class TankController : MonoBehaviour
{
    [Range(-10,10)][SerializeField] float mousePrecision = 4;
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] Transform muzzle = null;
    [SerializeField] float bulletSpeed = 3;

    TankMover tankMover;

    private void Awake()
    {
        tankMover = GetComponent<TankMover>();
    }

    public void Update()
    {
        tankMover.MoveForward();
        ReadChangeDirectionInput();
        tankMover.RotateTankHead(CalculateMouseCursorPoint());

        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Vector3 bulletRotation = bulletPrefab.transform.eulerAngles;
        //    bulletRotation.y = tankHead.eulerAngles.y;

        //    GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.Euler(bulletRotation));
        //    bullet.GetComponent<Rigidbody>().velocity = tankHead.forward * bulletSpeed;
        //}
    }

    private void ReadChangeDirectionInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tankMover.ChangeMoveDirection();
        }
    }

    private Vector3 CalculateMouseCursorPoint()
    {
        Vector3 mouseCursorPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            transform.position.z - Camera.main.transform.position.z + mousePrecision));

        return mouseCursorPoint;
    }
}
