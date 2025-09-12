using UnityEngine;

public class Collectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Add score, play sound, etc.
            Destroy(gameObject); // Remove the collectible
        }
    }
}