using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Camera camera;
    [SerializeField] private Weapon weapon;

    void Update()
    {
        //moving
        Vector2 way = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (way != Vector2.zero)
        {
            movement.Move(way, Input.GetButton("Run"));
        }

        //rotating
        var cursor = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        movement.Rotate(cursor);

        //shooting
        if (Input.GetButton("Fire"))
        {
            weapon.Shoot(Input.GetButton("Run"));
        }

        if (Input.GetButtonDown("Reload"))
        {
            weapon.Reload();
        }
    }
    
    void LateUpdate()
    {
        //camera follow
        camera.transform.position = gameObject.transform.position + Vector3.back * 10;
    }
}
