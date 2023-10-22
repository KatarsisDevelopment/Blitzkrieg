using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverScreen : MonoBehaviour
{
    public Tank Tank;
    void Start()
    {
        Tank = FindObjectOfType<Tank>();
    }
    public void GameOver()
    {
        gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
