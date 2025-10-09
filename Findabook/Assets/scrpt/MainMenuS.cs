using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("CutScene1");
    }

    public void SettingButton()
    {
         SceneManager.LoadScene("SettingsMenu");
    }
}