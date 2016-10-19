using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int bulletsInCage;
    [SerializeField] private float shootingSpeed;
    [SerializeField] private float shootAngleWalk;
    [SerializeField] private float shootAngleRun;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private int damage;

    [SerializeField] public GameObject bullet;

    private int bulletsNow;

    private bool reloading;
    private float reloadTimer;

    private bool pausing;
    private float pausingTimer;

    void Awake()
    {
        bulletsNow = bulletsInCage;
    }

    void Update()
    {
        if (reloading)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= reloadSpeed)
            {
                reloading = false;
            }
        }

        if (pausing)
        {
            pausingTimer += Time.deltaTime;
            if (pausingTimer >= shootingSpeed)
            {
                pausing = false;
            }
        }
    }

    public void Shoot(bool isRunning)
    {
        if (bulletsNow <= 0)
        {
            Reload();
            return;
        }
        if (!pausing && !reloading)
        {
            //warped angle
            var range = isRunning ? shootAngleRun : shootAngleWalk;
            var angle = new Vector3(0, 0, Random.Range(-1 * range, range) + transform.rotation.eulerAngles.z);
            //position for bllet
            var place = new Vector3(transform.position.x + 1.5f * Mathf.Cos((angle.z + 90f) * Mathf.Deg2Rad), 
                                    transform.position.y + 1.5f * Mathf.Sin((angle.z + 90f) * Mathf.Deg2Rad), 
                                    transform.position.z);
            //spawned bullet(clone) gameobject
            var shot = (GameObject)Instantiate(bullet, place, Quaternion.Euler(angle));
            //adding force for movement
            shot.GetComponent<Rigidbody2D>().AddForce(shot.transform.up * bulletSpeed);
            //have no idea how to store damage param
            shot.GetComponent<Bullet>().Damage = damage;
            //next shot delay
            pausing = true;
            bulletsNow--;
        }
    }

    public void Reload()
    {
        if (bulletsNow < bulletsInCage)
        {
            bulletsNow = bulletsInCage;
            reloading = true;
            reloadTimer = 0;
        }
    }
}
