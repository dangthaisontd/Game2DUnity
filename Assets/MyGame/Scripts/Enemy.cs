using System;
using UnityEngine;

public class Enemy : MonoBehaviour,IcanTakeDamage
{
    [Header("Enemy Settings")]
    public float maxHealth = 100f;
    private float currentHealth;
    private bool isDead = false;
    private Rigidbody2D rb;
    private float timeDestroy=0.2f;
    public float nextAttack;
    public float attackRate = 1f;
    public int damagePlayer=20;
    private EnemyAI enemyAI;
    public void TakeDamage(int damageAmount, Vector2 hitPoint, GameObject hitDirection)
    {
       if(isDead) return;
       currentHealth -= damageAmount;
        if(currentHealth <= 0)
         {
                isDead = true;
                Die();
        }
    }

    private void Die()
    {
        rb.linearVelocity= Vector2.zero;
        enemyAI.enabled = false;
        Destroy(gameObject, timeDestroy);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        enemyAI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead)
            return;
        if(collision.CompareTag("Player"))
        {
            if(collision.GetComponent<Player>().GetIsDead()==false)
            {
                collision.GetComponent<Player>().TakeDamage(20, transform.position, gameObject);
                if(Time.time >= nextAttack)
                {
                    nextAttack = Time.time + attackRate; // Adjust attack rate as needed
                    IcanTakeDamage damageable = collision.GetComponent<IcanTakeDamage>();
                    if(damageable != null)
                    {
                        damageable.TakeDamage(damagePlayer, Vector2.right, gameObject);
                    }
                }   
            }
        }
    }
}
