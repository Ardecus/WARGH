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

    public void Shoot(string target, bool isRunning)
    {
        if (bulletsNow == 0)
        {
            Reload();
            return;
        }
        if (!pausing && !reloading)
        {
            /*
            var range = isRunning ? shootAngleRun : shootAngleWalk;
            var angle = new Vector3(transform.rotation.x,
                                    transform.rotation.y,
                                    transform.rotation.z);
                                    //Random.Range(-1 * range, range) * Mathf.Deg2Rad + transform.rotation.z);
            var place = new Vector3(transform.position.x,// + 2 * Mathf.Cos(angle.z), 
                                    transform.position.y,// + 2 * Mathf.Sin(angle.z), 
                                    transform.position.z);
            var proj = (GameObject)Instantiate(bullet, place, Quaternion.Euler(angle));
            proj.GetComponent<Rigidbody2D>().AddForce(proj.transform.forward * bulletSpeed);
            proj.transform.rotation = Quaternion.Euler(transform.rotation.x,
                                                       transform.rotation.y,
                                                       transform.rotation.z - 90);
            var model = proj.GetComponent<Bullet>();
            model.Damage = damage;
            model.ShootTarget = target;
            */
            //shitload
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
