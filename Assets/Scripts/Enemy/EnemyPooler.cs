using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public GameObject Infantry,Artilerry,Vehicle;
    public int poolSize = 10;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
         
            if (i % 5 == 0)
            {
                GameObject obj = Instantiate(Artilerry);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
            else
            {
                GameObject obj = Instantiate(Infantry);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
            if (i % 10 == 0)
            {
                GameObject obj = Instantiate(Vehicle);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }
}
