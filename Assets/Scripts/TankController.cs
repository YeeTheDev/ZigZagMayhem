using UnityEngine;

[RequireComponent(typeof(TankMover))]
[RequireComponent(typeof(Shooter))]
public class TankController : MonoBehaviour
{
    [Range(-10,10)][SerializeField] float mousePrecision = 4;
    [SerializeField] float deathHeight = -2f;

    TankMover tankMover;
    Shooter shooter;
    PlayerStats playerStats;

    private void Awake()
    {
        tankMover = GetComponent<TankMover>();
        shooter = GetComponent<Shooter>();
        playerStats = GetComponent<PlayerStats>();

        playerStats.onDead += () => enabled = false; ;
    }

    private void Update()
    {
        tankMover.MoveForward();
        ReadChangeDirectionInput();
        tankMover.RotateTankHead(CalculateMouseCursorPoint());
        ReadShootInput();
        CheckIfFall();
    }

    private void ReadChangeDirectionInput() { if (Input.GetKeyDown(KeyCode.Space)) { tankMover.ChangeMoveDirection(); } }

    private Vector3 CalculateMouseCursorPoint()
    {
        Vector3 mouseCursorPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            transform.position.z - Camera.main.transform.position.z + mousePrecision));

        return mouseCursorPoint;
    }

    private void ReadShootInput() { if (Input.GetKeyDown(KeyCode.Mouse0)) { shooter.CheckIfCanShoot(); } }

    private void CheckIfFall() { if (transform.position.y < deathHeight) { playerStats.PlayDeadSequence(); } }
}
