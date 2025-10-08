using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public Image image;
    public Sprite[] cutsceneSprites;
    public string[] lines;
    public float textSpeed = 0.05f;
    public float imageDisplayTime = 2f; // Waktu tampilan gambar
    private int index;
    public string nextSceneName; // Nama scene berikutnya

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialog();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ✅ perbaikan Input
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                Debug.Log("selesai.");
            }
        }
    }

    void StartDialog()
    {
        index = 0;
        ShowCutsceneSprite();
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            ShowCutsceneSprite();
        }
        else
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(nextSceneName); // Pindah ke scene berikutnya
        }
    }
    void ShowCutsceneSprite()
    {
        if (index < cutsceneSprites.Length)
        {
            image.sprite = cutsceneSprites[index];
        }
    }
}
