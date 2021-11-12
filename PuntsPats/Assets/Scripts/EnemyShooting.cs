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

  private LayerMask environmentMask, playerMask;

  void Start()
  {
    environmentMask = LayerMask.GetMask("Environment");
    playerMask = LayerMask.GetMask("Player");
  }

  // Update is called once per frame
  void Update()
  {
    //CalculateDistFromPlayer();
    PointGunRaycast();

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

  void PointGunRaycast() 
  {
    Vector2 startPos = gameObject.transform.position;
    Vector2 endPos = gameObject.transform.right * 5;
    
    Debug.DrawRay(startPos, endPos, Color.red);

    if(!Physics2D.Raycast(startPos, endPos, 5, environmentMask))
    {
      if(Physics2D.Raycast(startPos, endPos, 5, playerMask))
      {
        Shoot();
      }
    }
  }



}
