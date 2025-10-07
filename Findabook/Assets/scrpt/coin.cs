using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
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
            if (GameManager.Instance != null)
                GameManager.Instance.CollectCoin();
            else
                Debug.LogError("GameManager.Instance is null. Make sure a GameManager exists in the scene.");
            if (nextBall != null)
            {
                nextBall.SetActive(true); // Show Ball2
            }
            
            Destroy(gameObject); // remove coin from scene (or call pooling return)
        }
    }
}