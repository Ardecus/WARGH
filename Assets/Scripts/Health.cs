using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int hp;

    public void Decrease(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
