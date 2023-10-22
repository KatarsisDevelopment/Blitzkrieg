using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public int Money,Cost,Level,UprageObjeCount,Damage,Armor;
    public TextMeshProUGUI MoneyText, LevelText,CostText,DamageText,ArmorText;
    public GameObject[] Panels,UprageObjects;
    public Button BuyButton;
    public GameObject Tank;
    private void Start()
    {
        Money = PlayerPrefs.GetInt("Gold",Money);
    }
    private void Update()
    {
        DamageText.text = "" + Damage;
        ArmorText.text = "" + Armor;
        MoneyText.text = "" + Money;
        LevelText.text = "Tank LEVEL: " + Level;
        if (UprageObjeCount < 3)
        {
            if (Level % 10 == 0 && Level != 0)
            {
                Level += 1;
                UprageObjects[UprageObjeCount].gameObject.SetActive(true);
                UprageObjeCount += 1;
            }
            CostText.text = "" + Cost;
        }
        else
        {
            CostText.text = "Max";
            BuyButton.interactable = false;
        }
        Tank.transform.Rotate(Vector3.up*Time.deltaTime*20f);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void UpragePanel()
    {
        Panels[0].gameObject.SetActive(true);
        Panels[1].gameObject.SetActive(false);
    }
    public void PlayPanel()
    {
        Panels[0].gameObject.SetActive(false);
        Panels[1].gameObject.SetActive(true);
    }
    public void Buy()
    {
        if (Cost <= Money)
        {
            PlayerPrefs.GetInt("Gold", Money -= Cost);
            Cost += 100;
            Level += 1;
            Damage += 10;
            Armor += 10;
        }
    }
}
