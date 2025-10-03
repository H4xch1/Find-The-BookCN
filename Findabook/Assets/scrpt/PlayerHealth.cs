using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;  // kasih HP besar biar gak mati dulu
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player kena peluru! HP tersisa: " + currentHealth);

        // sementara tidak ada fungsi Die()
        // kalau sudah selesai test, bisa aktifkan lagi
        Die();
    }

    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}