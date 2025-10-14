using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class winManager : MonoBehaviour
{
    public static winManager Instance;
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
        remainingCoins++;
        Debug.Log("Coin collected. Remaining: " + remainingCoins);
    }
}
