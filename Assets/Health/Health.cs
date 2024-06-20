using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // player hurt
            anim.SetTrigger("Hurt");
        }
        else
        {
            // player die
            if (!dead)
            {
                anim.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    }

    public void ResetHealth()
    {
        currentHealth = startingHealth;
        dead = false;
        anim.ResetTrigger("Die"); // Reset die trigger in case it affects the animation state
        //anim.SetTrigger("IDLEanim");  // Assuming "Idle" is a valid state to return to
    }

    public void SetCurrentHealth(float health)
    {
        currentHealth = health;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    }
}
