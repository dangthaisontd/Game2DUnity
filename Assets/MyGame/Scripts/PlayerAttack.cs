using System;
using System.Collections;
using UnityEngine;
[AddComponentMenu("DangSon/PlayerAttack")]
public class PlayerAttack : MonoBehaviour
{
    public float radius = 0.5f;
    public Transform pointAttack;
    public float attackRange = 0.5f;
    public float nextAttack = 0;
    public float timeDelay = 0.2f;
    public LayerMask enemyLayer;
    public int damageToGive = 10;
    private Animator anim;
    private int isAttackAnimationId;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim= GetComponentInChildren<Animator>();
        isAttackAnimationId = Animator.StringToHash("isAttack");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger(isAttackAnimationId);
            GetkeyR();
        }
    }

    private bool GetkeyR()
    {
        if (Time.time >= nextAttack)
        {
            nextAttack = Time.time + timeDelay;
            StartCoroutine(Attack());
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator Attack()
    {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(pointAttack.position, attackRange, enemyLayer);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<IcanTakeDamage>()?.TakeDamage(damageToGive, pointAttack.position, gameObject);
            }
            yield return new WaitForSeconds(0.1f);
    }
    private void OnDrawGizmosSelected()
    {
        if(pointAttack == null)
            return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pointAttack.position, attackRange);
    }
}
