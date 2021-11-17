using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
  public AIPath aIPath;
  Vector2 direction;
  public GameObject player;
  public Transform firePoint;

  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.Find("Player");
  }

  // Update is called once per frame
  void Update()
  {
    DecideLookMethod();
  }

  // this logic is to fix the problem where the enemy spins when colliding with the player
  void DecideLookMethod()
  {
    if(CalculateDistFromPlayer() >= 1.5f)
    {
      LookAtPlayerFar();
    }
    else
    {
      LookAtPlayerNear();
    }
  }

  void LookAtPlayerFar()
  {
    Vector3 dir = player.transform.position - firePoint.transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
  }

  void LookAtPlayerNear()
  {
    Vector3 dir = player.transform.position - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
  }

  float CalculateDistFromPlayer()
  {
    if (player.transform)
    {
      float distance = Vector2.Distance(player.transform.position, transform.position);
      return distance;
    }
    return 0f;
  }
}
