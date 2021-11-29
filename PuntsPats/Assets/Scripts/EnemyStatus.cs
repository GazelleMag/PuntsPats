using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
  public int maxHealth = 100;
  public int currentHealth;
  public GameObject healthBarCanvasPrefab, healthBarCanvas;
  public HealthBar healthBar;

  /*void Start()
  {
    healthBarCanvas = Instantiate(healthBarCanvasPrefab, healthBarCanvasPrefab.transform.position, healthBarCanvasPrefab.transform.rotation) as GameObject;
    healthBar = healthBarCanvas.GetComponentInChildren<HealthBar>();
    healthBar.SetMaxHealth(maxHealth);
    currentHealth = maxHealth;
    Debug.Log(healthBar);
  }

  void Update()
  {

  }

  void TakeDamage(int damage)
  {
    currentHealth -= damage;
    healthBar.SetHealth(currentHealth);
  }*/
}
