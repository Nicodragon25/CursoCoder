using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject gameOverPanel;


    private void Awake()
    {
        FindObjectOfType<Player>().OnPlayerDeath += GameOver;
        gameManager = FindObjectOfType<GameManager>().gameObject;
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        gameManager.GetComponent<GameManager>().RestartLevel();
    }
}
