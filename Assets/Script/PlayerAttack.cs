
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 3;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
   // [SerializeField] private AudioClip fireballSound;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private bool atck;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Debug.Log("Kepencet");
            Attack();
            
            
        }
            
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        //SoundManager.instance.PlaySound(fireballSound);
        anim.SetBool("attack",true);
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        Invoke("AttackFalse", 0.5f);
    }

    private void AttackFalse()
    {
        anim.SetBool("attack", false);
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
