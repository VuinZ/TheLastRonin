using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timerstart : MonoBehaviour
{
    public GameObject canvastimenbar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvastimenbar.SetActive(true);
        }
    }
}
