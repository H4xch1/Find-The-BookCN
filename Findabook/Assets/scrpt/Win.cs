using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string winSceneName = "Victory";
    [HideInInspector] public int remainingCoins;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f); // Wait a bit for coins to spawn
        remainingCoins = GameObject.FindGameObjectsWithTag("Collectible").Length;
        Debug.Log("Starting coins: " + remainingCoins);

        foreach (var coin in GameObject.FindGameObjectsWithTag("Collectible"))
        Debug.Log("Found coin: " + coin.name);

    }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RefreshCoins()
    {
        remainingCoins = GameObject.FindGameObjectsWithTag("Collectible").Length;
        Debug.Log("Coin count refreshed: " + remainingCoins);
    }

    public void CollectCoin()
    {
        remainingCoins--;
        Debug.Log("Coin collected. Remaining: " + remainingCoins);
        if (remainingCoins <= 0)
        {
            SceneManager.LoadScene(winSceneName);
        }
    }
}
