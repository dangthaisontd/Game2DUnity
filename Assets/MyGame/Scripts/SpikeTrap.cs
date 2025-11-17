using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [Header("Damage Settings")]
    public int damageAmount = 100;
    [Header("Audio Settings")]
    public AudioClip spikeSound;
    public GameObject fxPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            IcanTakeDamage canTakeDamage = collision.GetComponent<IcanTakeDamage>();
            if(canTakeDamage != null)
            {
                canTakeDamage.TakeDamage(damageAmount, transform.position, gameObject);
                if(spikeSound != null)
                {
                   AudioManager.Instance.PlaySfx(spikeSound);
                }
                if(fxPrefabs != null)
                {
                    Instantiate(fxPrefabs, transform.position, Quaternion.identity);
                }
            }
        }
    }
}
