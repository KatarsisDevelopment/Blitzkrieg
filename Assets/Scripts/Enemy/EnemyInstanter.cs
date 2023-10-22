using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstanter : MonoBehaviour
{
    public  EnemyPooler EnemyPooler;
    public Transform[] SpawnPoints;
    public float InstantinateSpeed = 1f;
    Tank Tank;
    void Start()
    {
        Tank = FindObjectOfType<Tank>();
        StartCoroutine(EnemyActiver());
    }
    IEnumerator EnemyActiver()
    {
        while (true)
        {
            GameObject enemy = EnemyPooler.GetPooledObject();
            if (enemy != null)
            {
                enemy.transform.position = Tank.transform.position + SpawnPoints[Random.Range(0,SpawnPoints.Length)].position;
                enemy.SetActive(true);
            }
            yield return new WaitForSecondsRealtime(InstantinateSpeed);
        }
      
    }
}
