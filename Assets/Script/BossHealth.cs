using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{

    public int health = 10;
    public GameObject canvastimer;
    

    public bool isInvulnerable = false;

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
        Destroy(gameObject);
        float finalTime = TImer.instance.GetElapsedTime();

        PlayerPrefs.SetFloat("FinalTime", finalTime);
        TImer.instance.ResetTimer();
        canvastimer.SetActive(false);
        SceneManager.LoadScene("ScoreBoard");
        
    }

}