using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    SpriteRenderer spriteRenderer;
    private PlayerHealth health;
    public GameObject canvastimenbar;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<PlayerHealth>(); 
    }

    private void Start()
    {
        checkpointPos = transform.position;
        canvastimenbar.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spike"))
        {
            Die();
        }
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

    void Die()
    {
        health.TakeDamage(health.currentHealth);
        StartCoroutine(Respawn(0.5f));
    }

    private void Update()
    {
        if (health.currentHealth <= 0) 
        {
            Die();
        }
    }

    IEnumerator Respawn(float duration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        health.ResetHealth(); // Reset health
        spriteRenderer.enabled = true;
        GetComponent<PlayerMovement>().enabled = true; // Aktifkan kembali movement player
    }
}
