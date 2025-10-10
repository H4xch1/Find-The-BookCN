using UnityEngine;
using UnityEngine.UI;

public class SoundManagerS : MonoBehaviour
{
    [SerializeField] Image IconOn;
    [SerializeField] Image IconOff;
    private bool muted = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
        }

        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            IconOn.enabled = true;
            IconOff.enabled = false;
        }

        else
        {
            IconOn.enabled = false;
            IconOff.enabled = true;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }



}