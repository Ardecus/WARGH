using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public int Damage;
    public string ShootTarget;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(ShootTarget))
        {
            other.gameObject.GetComponent<Health>().Decrease(Damage);
        }
        Destroy(gameObject);
    }
}
