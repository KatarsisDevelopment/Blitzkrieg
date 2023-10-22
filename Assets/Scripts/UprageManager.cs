using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UprageManager : MonoBehaviour
{
    Tank Tank;
    public GameObject UpragePanel;
    void Start()
    {
        Tank = FindObjectOfType<Tank>();
    }
    public void FireSpeed()
    {
        Tank.ShotTime -= 0.125f;
        UpragePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void DamageUprage()
    {
        Tank.Damage += 10;
        UpragePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void ArmorUprage()
    {
        Tank.HP += 100;
        UpragePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Repair()
    {
        Tank.Repair();
        UpragePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Speed()
    {
        Tank.Speed += Tank.Speed / 4f;
        UpragePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
