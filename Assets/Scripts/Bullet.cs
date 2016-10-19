using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage;

    private float timer;
    private const float lifeTime = 10;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            other.gameObject.GetComponent<Health>().Decrease(Damage);
        }
        Destroy(gameObject);
    }
}
