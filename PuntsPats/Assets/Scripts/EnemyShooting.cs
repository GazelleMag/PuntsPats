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
    //CalculateDistFromPlayer();
    DrawRaycast();

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

  /*void CalculateDistFromPlayer()
  {
    if (playerTransform)
    {
      float distance = Vector2.Distance(playerTransform.position, transform.position);
      print("My distance from player is: " + distance);
    }
  }*/

  void DrawRaycast() {
    Vector2 startPos = gameObject.transform.position;
    Vector2 endPos = gameObject.transform.right * 5;
    Debug.DrawRay(startPos, endPos, Color.red);

    LayerMask environmentMask = LayerMask.GetMask("Environment");
    LayerMask playerMask = LayerMask.GetMask("Player");

    //RaycastHit2D hit = Physics2D.Raycast(startPos, endPos, 5, mask);

    /*if(Physics.Raycast (startPos, endPos, out hit)) {
      Debug.Log(hit.transform.name + " was hit");
    }*/

    /*if(hit.collider != null) {
      Debug.Log(hit.transform.name + " was hit");
    }*/

    if(!Physics2D.Raycast(startPos, endPos, 5, environmentMask))
    {
      Debug.Log("A wall is not being it!");
      if(Physics2D.Raycast(startPos, endPos, 5, playerMask))
      {
        Debug.Log("Player is being it!");
      }
    }

  }
}
