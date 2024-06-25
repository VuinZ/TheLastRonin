using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int health = 10;
    public bool isInvulnerable = false;

    // Menambahkan referensi ke skrip Timer
    private Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>(); // Mencari objek Timer di scene
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= 5)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Simpan waktu menggunakan PlayerPrefs
        PlayerPrefs.SetFloat("FinalTime", timer.GetElapsedTime());

        Destroy(gameObject);
        SceneManager.LoadScene("ScoreBoard");
    }
}
