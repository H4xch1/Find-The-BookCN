using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;  // kasih HP besar biar gak mati dulu
    private int currentHealth;

    public Image[] health;
    public Sprite HealthFull;
    public Sprite HealthNull;
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player kena peluru! HP tersisa: " + currentHealth);
        UpdateHearts();

        // sementara tidak ada fungsi Die()
        // kalau sudah selesai test, bisa aktifkan lagi
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void UpdateHearts()
    {
        for (int i = 0; i < health.Length; i++)
        {
            if (i < currentHealth)
                health[i].sprite = HealthFull;
            else
                health[i].sprite = HealthNull;
        }
    }

    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}