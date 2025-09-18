using UnityEngine;

public class EnemyAutoShoot : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 2f;
    public float moveDistance = 3f;
    private Vector2 startPos;
    private bool movingRight = true;

    [Header("Shooting")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    private float shootTimer;

    public int minProjectiles = 3;
    public int maxProjectiles = 6;
    public float spreadAngle = 45f;

    private Transform player;

    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shootTimer = shootInterval;
    }

    void Update()
    {
        FlyPatrol();
        AutoShoot();
    }

    void FlyPatrol()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (Vector2.Distance(startPos, transform.position) >= moveDistance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (Vector2.Distance(startPos, transform.position) >= moveDistance)
                movingRight = true;
        }
    }

    void AutoShoot()
    {
        if (player == null) return;

        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            ShootSpread();
            shootTimer = shootInterval;
        }
    }

    void ShootSpread()
    {
        Vector2 baseDir = (player.position - firePoint.position).normalized;
        int numProjectiles = Random.Range(minProjectiles, maxProjectiles + 1);

        for (int i = 0; i < numProjectiles; i++)
        {
            float angle = Random.Range(-spreadAngle, spreadAngle);
            Vector2 spreadDir = Quaternion.Euler(0, 0, angle) * baseDir;

            GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            proj.GetComponent<StraightProjectile>().SetInitialDirection(spreadDir);
        }
    }
}
