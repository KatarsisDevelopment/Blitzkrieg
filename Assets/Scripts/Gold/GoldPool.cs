using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPool : MonoBehaviour
{
    public static GoldPool goldpool;
    public List<GameObject> EffectList = new List<GameObject>();
    public int EffectCount;
    [SerializeField] private GameObject EffectObject;
    private void Awake()
    {
        if (goldpool == null)
        {
            goldpool = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < EffectCount; i++)
        {
            GameObject bullet = Instantiate(EffectObject);
            bullet.SetActive(false);
            EffectList.Add(bullet);
        }
    }
    public GameObject GetGold()
    {
        foreach (var obj in EffectList)
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
