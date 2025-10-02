using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryS : MonoBehaviour
{
    public void ButtonHome()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonReload()
    {
        SceneManager.LoadScene("Iwak");
    }
}
