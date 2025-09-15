using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining; 
    public Text timerText; 
    public string deathSceneName = "GameOver"; 

    void Update()
    {
        timeRemaining -= Time.deltaTime;
        timerText.text = Mathf.Ceil(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            SceneManager.LoadScene(deathSceneName);
        }
    }
}