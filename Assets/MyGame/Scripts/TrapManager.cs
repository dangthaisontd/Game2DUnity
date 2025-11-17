using Unity.VisualScripting;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public int damage = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.CompareTag("Player"))
            {
                  IcanTakeDamage playerTakedamage = collision.GetComponent<IcanTakeDamage>();
                if (playerTakedamage != null)
                {
                    playerTakedamage.TakeDamage(damage,Vector2.zero, gameObject);
                }
            }
       
    }
}
