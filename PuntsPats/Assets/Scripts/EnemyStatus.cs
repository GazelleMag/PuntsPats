using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
  public int maxHealth = 100;
  public int currentHealth;
  public LevelController levelController;
  public HealthBar healthBar;

  void Start()
  {
    currentHealth = maxHealth;

    levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
    healthBar = gameObject.GetComponentInChildren<HealthBar>();
  }

  void Update()
  {
    if(currentHealth <= 0)
    {
      Die();
    }
  }

  public void TakeDamage(int damage)
  {
    currentHealth -= damage;
    healthBar.SetHealth(currentHealth);
  }

  void Die()
  {
    Destroy(gameObject);
    levelController.DecrementEnemy();
  }
}
