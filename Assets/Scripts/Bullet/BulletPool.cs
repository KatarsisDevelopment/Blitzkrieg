using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;
    public List<GameObject> BulletList = new List<GameObject>();
    public int BulletCount;
    [SerializeField] private GameObject BulletObject;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < BulletCount; i++)
        {
            GameObject bullet = Instantiate(BulletObject);
            bullet.SetActive(false);
            BulletList.Add(bullet);
        }
    }
    public GameObject GetBullet()
    {
        foreach (var obj in BulletList)
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
