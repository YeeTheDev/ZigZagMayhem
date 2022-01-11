using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3;
    [SerializeField] Transform tankHead = null;

    Rigidbody rb;

    private void Awake() { rb = GetComponent<Rigidbody>(); }

    public void MoveForward() { rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime); }
    public void ChangeMoveDirection() { transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles* -1); }

    public void RotateTankHead(Vector3 mouseCursorPoint)
    {
        mouseCursorPoint.y = tankHead.position.y;
        tankHead.LookAt(mouseCursorPoint, Vector3.up);
    }
}
