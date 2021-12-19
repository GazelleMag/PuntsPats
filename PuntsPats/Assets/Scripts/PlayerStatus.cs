using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
  public int maxHealth = 100;
  public int currentHealth;
  public HealthBar healthBar;
  public LevelController levelController;

  void Start()
  {
    healthBar = gameObject.GetComponentInChildren<HealthBar>();
    currentHealth = maxHealth;
    healthBar.SetMaxHealth(maxHealth);
  }

  void Update()
  {
    if (currentHealth <= 0)
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
    levelController.ShowGameOverScreen();
    //Destroy(gameObject);
  }
}
