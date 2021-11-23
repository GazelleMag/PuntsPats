using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnPoint : MonoBehaviour
{
  public GameObject[] spawnLocations;
  public GameObject enemy;
  //private Vector3 respawnLocation;

  void Awake() 
  {
    spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
    Debug.Log(spawnLocations);
  }

  // Start is called before the first frame update
  void Start()
  {
    //respawnLocation = enemy.transform.position;
    SpawnEnemy();
  }

  void SpawnEnemy()
  {
    int spawn = Random.Range(0, spawnLocations.Length);
    GameObject.Instantiate(enemy, spawnLocations[spawn].transform.position, Quaternion.identity);
  }
}
