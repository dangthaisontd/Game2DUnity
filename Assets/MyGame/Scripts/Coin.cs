using Unity.VisualScripting;
using UnityEngine;
[AddComponentMenu("DangSon/Coin")]
public class Coin : MonoBehaviour
{
    public AudioClip coinClip;
    public int coinValue = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.onCoinChanged.Invoke(coinValue);
            AudioManager.Instance.PlaySfx(coinClip);
            Destroy(gameObject);
        }
    }
}
