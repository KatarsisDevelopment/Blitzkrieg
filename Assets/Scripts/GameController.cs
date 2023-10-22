using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    EnemyInstanter EnemyInstanter;
    public float time= 0;
    public TextMeshProUGUI timeText;
    void Start()
    {
        EnemyInstanter = FindObjectOfType<EnemyInstanter>();
    }
    void Update()
    {
        if (Camera.main.orthographicSize >= 60)
        {
            Camera.main.orthographicSize -= 20f * Time.deltaTime;
        }
        time += Time.deltaTime;
        DisplayTime(time);
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
