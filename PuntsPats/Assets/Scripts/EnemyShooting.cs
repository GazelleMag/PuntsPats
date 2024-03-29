using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
  public Transform firePoint;
  public GameObject bulletPrefab;
  private float bulletForce = 20f;
  private bool lookingAtPlayer = false;
  private Rigidbody2D enemyRb;

  public PlayerAnimation playerAnimation;
  private LayerMask environmentMask, playerMask;

  private float fireRate = 0.5f;
  private float nextFire = 0.0f;

  void Start()
  {
    environmentMask = LayerMask.GetMask("Environment");
    playerMask = LayerMask.GetMask("Player");
  }

  void Update()
  {
    PointGunRaycast();
    
    if (lookingAtPlayer)
    {
      Shoot();
    }

    //time to reload
    //Reload()
  }

  void Shoot()
  {
    if (Time.time > nextFire)
    {
      nextFire = Time.time + fireRate;
      GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
      Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
      rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
  }

  void PointGunRaycast()
  {
    Vector2 startPos = firePoint.transform.position;
    Vector2 endPos = firePoint.transform.right * 5;
    endPos = RotateVector2(endPos, 1.60f);

    Debug.DrawRay(startPos, endPos, Color.red);

    lookingAtPlayer = LookingAtPlayer(startPos, endPos);
  }

  bool LookingAtPlayer(Vector2 startPos, Vector2 endPos)
  {
    if (!Physics2D.Raycast(startPos, endPos, 5, environmentMask))
    {
      if (Physics2D.Raycast(startPos, endPos, 5, playerMask))
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    return false;
  }

  //I use this to rotate the raycast
  Vector2 RotateVector2(Vector2 vec, float delta)
  {
    return new Vector2(
            vec.x * Mathf.Cos(delta) - vec.y * Mathf.Sin(delta),
            vec.x * Mathf.Sin(delta) + vec.y * Mathf.Cos(delta)
        );
  }

}
