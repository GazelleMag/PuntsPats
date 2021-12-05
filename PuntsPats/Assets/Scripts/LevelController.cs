using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
  private int enemyTotal = 4, enemyCounter = 4;
  private int spawnIndex, lastSpawnIndex;
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
    KeepNumberOfEnemies();
  }

  int ChooseRandomSpawnPoint()
  {
    int spawnIndex = Random.Range(0, spawnPoints.Length);
    while (spawnIndex == lastSpawnIndex)
    {
      spawnIndex = Random.Range(0, spawnPoints.Length);
    }
    lastSpawnIndex = spawnIndex;
    return spawnIndex;
  }

  void SpawnEnemy(int spawnIndex)
  {
    GameObject.Instantiate(enemyPrefab, spawnPoints[spawnIndex].transform.position, Quaternion.identity);
  }

  void InitialSpawnEnemy()
  {
    for (int i = 0; i < spawnPoints.Length; i++)
    {
      SpawnEnemy(i);
    }
  }

  void KeepNumberOfEnemies()
  {
    if (enemyCounter != enemyTotal)
    {
      spawnIndex = ChooseRandomSpawnPoint();
      SpawnEnemy(spawnIndex);
      enemyCounter++;
    }
  }

  public void DecrementEnemy()
  {
    enemyCounter--;
  }
}
