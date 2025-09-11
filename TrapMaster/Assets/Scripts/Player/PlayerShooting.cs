using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootDelay = 1f;
    [SerializeField] private float speed = 50f;

    private Transform bulletSpawn;
    private int bulletDamage = 5;
    private float timer = 0;

    private void Awake()
    {
        bulletSpawn = transform.GetChild(1).gameObject.GetComponent<Transform>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timer <= 0) Fire();
        }
    }

    private void Fire()
    {
        timer = shootDelay;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        bullet.GetComponent<BulletControl>().SetDamage(bulletDamage);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        Destroy(bullet, 5f);
    }

    public void SetMoveSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetShootingDelay(float shootDelay)
    {
        this.shootDelay = shootDelay;
    }

    public void SetBulletDamage(int dmg)
    {
        bulletDamage = dmg;
    }
}
