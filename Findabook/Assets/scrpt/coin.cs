using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Collectible : MonoBehaviour
{
    public GameObject nextBall; 
    public GameObject[] balls; 
    void Start()
    {
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].SetActive(i == 0); 
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
                nextBall.SetActive(true); 
            }
            
            Destroy(gameObject); 
        }
    }
}