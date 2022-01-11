using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankController : MonoBehaviour
{
    [SerializeField] Transform tankHead = null;
    [Range(-10,10)][SerializeField] float mousePrecision = 4;
    [SerializeField] float moveSpeed = 2;
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] Transform muzzle = null;
    [SerializeField] float bulletSpeed = 3;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {

        rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles * -1);
        }

        RotateCannonToMouseCursor();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 bulletRotation = bulletPrefab.transform.eulerAngles;
            bulletRotation.y = tankHead.eulerAngles.y;

            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.Euler(bulletRotation));
            bullet.GetComponent<Rigidbody>().velocity = tankHead.forward * bulletSpeed;
        }
    }

    private void RotateCannonToMouseCursor()
    {
        Vector3 mouseCursorPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            transform.position.z - Camera.main.transform.position.z + mousePrecision));
        mouseCursorPoint.y = tankHead.position.y;

        tankHead.LookAt(mouseCursorPoint, Vector3.up);
    }
}
