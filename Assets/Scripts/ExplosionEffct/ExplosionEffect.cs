using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("Disabler", Time.deltaTime, 1f);
    }
    void Disabler()
    {
        gameObject.SetActive(false);
    }
   
}
