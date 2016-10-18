using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private Rigidbody2D rbody;

    public void Rotate(Vector3 point)
    {
        float angle = Mathf.Atan2(point.y - transform.position.y, point.x - transform.position.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void Move(Vector2 point, bool isRunning)
    {
        rbody.MovePosition(rbody.position + point * Time.deltaTime * (isRunning ? runningSpeed : walkingSpeed));
    }
}
