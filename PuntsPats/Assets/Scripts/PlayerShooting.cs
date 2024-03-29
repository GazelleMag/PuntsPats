using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
  public Transform firePoint;
  public GameObject bulletPrefab;
  public float bulletForce = 20f;
  public PlayerAnimation playerAnimation;
  public LevelController levelController;
  private bool gameOver;

  private float fireRate = 0.125f;
  private float nextFire = 0.0f;

  void Start()
  {
    gameOver = levelController.gameOver;
  }

  void Update()
  {
    if (Input.GetButton("Fire1") && gameOver == false)
    {
      if (!GameIsOver())
      {
        Shoot();
        playerAnimation.ShootAnimTransition();
      }
    }

    if (Input.GetKeyDown(KeyCode.R))
    {
      playerAnimation.ReloadAnimTransition();
    }
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

  bool GameIsOver()
  {
    gameOver = levelController.gameOver;
    if (gameOver)
    {
      return true;
    }
    return false;
  }
}
