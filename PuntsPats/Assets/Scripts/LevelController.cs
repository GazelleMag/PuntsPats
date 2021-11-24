using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
  private int enemyTotal = 2, enemyCounter = 0;
  private int spawnIndex;
  public GameObject[] spawnPoints;
  public GameObject enemyPrefab;
  
  void Awake()
  {
    spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
  }

  void Start()
  {
    InitialSpawnEnemy();
  }

  void Update()
  {
    /*if(enemyCounter != enemyTotal)
    {
      spawnIndex = ChooseRandomSpawnPoint();
      SpawnEnemy(spawnIndex);
      enemyCounter++;
    }*/
  }

  void InitialSpawnEnemy()
  {
    for(int i = 0; i < spawnPoints.Length; i++)
    {
      SpawnEnemy(i);
    }
  }

  int ChooseRandomSpawnPoint()
  {
    int spawnIndex = Random.Range(0, spawnPoints.Length);
    return spawnIndex;
  }

  void SpawnEnemy(int spawnIndex)
  {
    GameObject.Instantiate(enemyPrefab, spawnPoints[spawnIndex].transform.position, Quaternion.identity);
  }
}
