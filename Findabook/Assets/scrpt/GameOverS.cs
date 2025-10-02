using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverS : MonoBehaviour
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
