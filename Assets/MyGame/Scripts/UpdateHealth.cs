using UnityEngine;
using UnityEngine.UI;

public class UpdateHealth : MonoBehaviour
{
    public Image healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     GameManager.Instance.onHealthd.AddListener(UpdateHealthBar);
    }

    // Update is called once per frame
    void UpdateHealthBar(int currentHealth, int maxHealth)
    {
       
        float health = (float) currentHealth /maxHealth;
        healthBar.fillAmount =(float)health;
    }
   
}
