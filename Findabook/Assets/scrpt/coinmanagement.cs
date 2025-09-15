using UnityEngine;
using UnityEngine.UI;

public class coinmanagement : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       coinText.text = "Coin : " + coinCount.ToString();
    }
}
