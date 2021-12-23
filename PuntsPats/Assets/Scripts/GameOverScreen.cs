using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
  public Text enemiesKilledText;
  public LevelController levelController;

  public void SetupScreen(int enemiesKilled)
  {
    levelController.gameOver = true;
    gameObject.SetActive(true);
    enemiesKilledText.text = "ENEMIES KILLED: " + enemiesKilled.ToString();
  }

  public void PlayAgainButton()
  {
    levelController.gameOver = false;
    SceneManager.LoadScene("Level");
  }

  public void QuitButton()
  {
    Debug.Log("Quitting game...");
    Application.Quit();
  }
}
