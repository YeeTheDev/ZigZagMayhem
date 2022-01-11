using UnityEngine;

public class TankMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3;
    [SerializeField] Transform tankHead = null;

    Rigidbody rb;

    private void Awake() { rb = GetComponent<Rigidbody>(); }

    //Called in TankController
    public void MoveForward() { rb.MovePosition(transform.position + transform.forward * moveSpeed * Time.deltaTime); }
    //Called in TankController
    public void ChangeMoveDirection() { transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles* -1); }

    //Called in TankController
    public void RotateTankHead(Vector3 mouseCursorPoint)
    {
        mouseCursorPoint.y = tankHead.position.y;
        tankHead.LookAt(mouseCursorPoint, Vector3.up);
    }
}
