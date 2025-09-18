using UnityEngine;

public class EnemyFlyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 3f;
    private Vector2 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
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
}
