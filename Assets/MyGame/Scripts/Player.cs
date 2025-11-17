using UnityEngine;
using UnityEngine.InputSystem.Processors;
[AddComponentMenu("DangSon/Player")]
public class Player : MonoBehaviour, IcanTakeDamage
{
    public int Maxhealth = 100;
    public int currentHealth;
    private bool isDead = false;
    private Animator anim;
    private int isDeadId;
    private int isDeadFall;
    private PlayerController playerController;
    private PlayerAttack playerAttack;
    private PlayerFire playerFire;
    void Start()
    {
        currentHealth = Maxhealth;
        anim = GetComponentInChildren<Animator>();
        isDeadId = Animator.StringToHash("isDead");
        isDeadFall = Animator.StringToHash("isDeadFall");
        playerController = GetComponent<PlayerController>();
        playerAttack = GetComponent<PlayerAttack>();
        playerFire = GetComponent<PlayerFire>();
    }
    public void TakeDamage(int damageAmount, Vector2 hitPoint, GameObject hitDirection)
    {
        if (isDead) return;
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            DeadPlayer();
        }
        // Add hit reaction logic here if needed
        GameManager.Instance.onHealthd.Invoke(currentHealth, Maxhealth);
    }
    private void DeadPlayer()
    {
        int randomDeath = Random.Range(0, 2);  //0,1
        if (randomDeath == 0)
            anim.SetTrigger(isDeadFall);
        else
            anim.SetTrigger(isDeadId);
        playerController.enabled = false;
        playerAttack.enabled = false;
        playerFire.enabled = false;
    }
    public bool GetIsDead()
    {
        return isDead; 
    }
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    public int GetMaxHealth()
    {
        return Maxhealth;
    }
}
