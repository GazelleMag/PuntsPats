using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public PlayerAnimation playerAnimation;
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        calculateDistFromPlayer();

        //time to shoot
        //Shoot();

        //time to reload
        //reload
    }

    void Shoot() 
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void calculateDistFromPlayer ()
    {
        if (playerTransform)
        {
            float distance = Vector2.Distance(playerTransform.position, transform.position);
            print("My distance from player is: " + distance);
        }
    }
}
