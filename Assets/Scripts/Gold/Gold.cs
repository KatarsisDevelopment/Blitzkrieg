using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
 
    void Update()
    {
        Tank tank = FindObjectOfType<Tank>();
        if (Vector3.Distance(transform.position, tank.transform.position) < 5f)
        {
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("Gold", tank.GoldCount+5);

        }
          transform.position =  Vector3.MoveTowards(transform.position, tank.transform.position, 50f * Time.deltaTime);
    }
  
}
