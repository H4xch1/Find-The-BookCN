using UnityEngine;

public class StraightProjectile : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 200f;   // seberapa cepat peluru bisa belok
    public float lifetime = 5f;
    public int damage = 1;

    private Transform player;
    private Vector2 currentDirection;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, lifetime);
    }

    public void SetInitialDirection(Vector2 dir)
    {
        currentDirection = dir.normalized;
    }

    void Update()
    {
        if (player == null)
        {
            transform.Translate(currentDirection * speed * Time.deltaTime);
            return;
        }

        // arah ke player
        Vector2 targetDir = (player.position - transform.position).normalized;

        // smooth belokan peluru
        currentDirection = Vector2.Lerp(currentDirection, targetDir, rotateSpeed * Time.deltaTime / 100f).normalized;

        transform.Translate(currentDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth hp = collision.GetComponent<PlayerHealth>();
            if (hp != null)
            {
                hp.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
