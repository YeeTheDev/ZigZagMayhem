using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] Transform tankHead = null;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    public void Update()
    {
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            transform.position.z - cam.transform.position.z));
        point.y = 0;

        tankHead.rotation = Quaternion.LookRotation(point, Vector3.up);
    }

}
