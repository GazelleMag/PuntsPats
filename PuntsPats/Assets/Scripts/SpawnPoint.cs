using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnPoint : MonoBehaviour
{
  public GameObject[] spawnLocations;
  public GameObject enemy;
  public GameObject player;
  private Vector3 respawnLocation;
  //private AIDestinationSetter destinationSetter; -> this should probably be called from one of the enemy's scripts

  void Awake() 
  {
    spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
  }

  // Start is called before the first frame update
  void Start()
  {
    //destinationSetter = gameObject.GetComponent(destinationSetter);
    respawnLocation = enemy.transform.position;
    player = GameObject.Find("Player");
    //Debug.Log(destinationSetter);
    //destinationSetter.target = player.transform;
    SpawnEnemy();
  }

  void SpawnEnemy()
  {
    int spawn = Random.Range(0, spawnLocations.Length);
    GameObject.Instantiate(enemy, spawnLocations[spawn].transform.position, Quaternion.identity);
  }
}
