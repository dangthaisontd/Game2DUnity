using System;
using UnityEngine;
[AddComponentMenu("DangSon/PlayerFire")]
public class PlayerFire : MonoBehaviour
{
    [Header("Bullet")]
    public GameObject bulletPrefab;
    public Transform bulletsPositon;
    public float bulletSpeed = 20f;
    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
       GameObject bullets = Instantiate(bulletPrefab, bulletsPositon.position, Quaternion.identity);
       Rigidbody2D rb = bullets.GetComponent<Rigidbody2D>();
       if(playerController.FaceRight())
        {
            rb.linearVelocity = Vector2.right * bulletSpeed;
        }
       else
          {
                rb.linearVelocity = Vector2.left * bulletSpeed;
          }
    }
}
