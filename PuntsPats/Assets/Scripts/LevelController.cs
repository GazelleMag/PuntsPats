using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
  private int enemyTotal = 4, enemyCounter = 4;
  private int spawnIndex, lastSpawnIndex;
  public GameObject[] spawnPoints;
  public GameObject enemyPrefab;
  public GameOverScreen gameOverScreen;
  public int killedEnemiesCount;
  public bool gameOver;

  void Awake()
  {
    spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
  }

  void Start()
  {
    gameOver = false;
    killedEnemiesCount = 0;
    InitialSpawnEnemy();
  }

  void Update()
  {
    KeepNumberOfEnemies();

    if (gameOver)
    {
      Time.timeScale = 0f;
    }
    else
    {
      Time.timeScale = 1f;
    }
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
    killedEnemiesCount++;
    enemyCounter--;
  }

  public void ShowGameOverScreen()
  {
    gameOverScreen.SetupScreen(killedEnemiesCount);
  }
}
