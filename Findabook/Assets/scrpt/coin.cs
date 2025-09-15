using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject nextBall; // Assign Ball2 in the Inspector
    public GameObject[] balls; // Array to hold Ball1, Ball2, Ball3

    void Start()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].SetActive(i == 0); // Only activate the first ball
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (nextBall != null)
            {
                nextBall.SetActive(true); // Show Ball2
            }
            // Add score, play sound, etc.
            Destroy(gameObject); // Remove the collectible
        }
    }
}