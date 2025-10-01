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
    public float shootInterval = 1f;   // tembak tiap 1 detik
    private float shootTimer;

    private Transform player;

    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shootTimer = 0f; // langsung bisa nembak di awal
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
            ShootOne();            // panggil fungsi tembak 1 peluru
            shootTimer = shootInterval;
        }
    }

    void ShootOne()
    {
        // arah ke player
        Vector2 dir = (player.position - firePoint.position).normalized;

        // spawn 1 peluru
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        proj.GetComponent<StraightProjectile>().SetInitialDirection(dir);
    }
}
