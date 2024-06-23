using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomTrigger : MonoBehaviour
{
    private Boss boss;

    private void Awake()
    {
        boss = FindObjectOfType<Boss>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            boss.isActive = true; // Aktifkan boss saat pemain menyentuh trigger

            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null && playerMovement.speed <= 10 && playerMovement.jumpingPower <= 15)
            {
                playerMovement.speed += 2; // Increase speed
                playerMovement.jumpingPower += 5; // Increase jump height
            }
        }
    }
}
