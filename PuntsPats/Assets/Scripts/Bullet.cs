using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float destroyTime = 3.5f;
  public GameObject hitEffect; //-> set an effect for the bullet

  public EnemyStatus enemyStatus;

  void Update()
  {
    if (gameObject)
    {
      Destroy(gameObject, destroyTime);
    }
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Enemy")
    {
      enemyStatus = collision.gameObject.GetComponent<EnemyStatus>();
      enemyStatus.TakeDamage(10);
      Destroy(gameObject);
    }
    else
    {
      GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
      Destroy(effect, 2.5f);
      Destroy(gameObject);
    }
  }
}
