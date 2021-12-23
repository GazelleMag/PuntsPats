using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float destroyTime = 3.5f;
  public GameObject hitEffect;

  public EnemyStatus enemyStatus;
  public PlayerStatus playerStatus;

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
      CollisionOnEnemy(collision);
    }
    else if (collision.gameObject.tag == "Player")
    {
      CollisionOnPlayer(collision);
    }
    else
    {
      CollisionOnWall();
    }
  }

  void CollisionOnEnemy(Collision2D collision)
  {
    enemyStatus = collision.gameObject.GetComponent<EnemyStatus>();
    enemyStatus.TakeDamage(10);
    Destroy(gameObject);
  }

  void CollisionOnPlayer(Collision2D collision)
  {
    playerStatus = collision.gameObject.GetComponent<PlayerStatus>();
    playerStatus.TakeDamage(10);
    Destroy(gameObject);
  }

  void CollisionOnWall()
  {
    GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    Destroy(effect, 2.5f);
    Destroy(gameObject);
  }

}
