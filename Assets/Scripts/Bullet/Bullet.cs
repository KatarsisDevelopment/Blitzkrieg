using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    TrailRenderer BulletTrail;
    private void Awake()
    {
        BulletTrail = GetComponentInChildren<TrailRenderer>();
        if (BulletTrail != null)
        {
            BulletTrail.enabled = false;
        }
    }
    private void Start()
    {
        InvokeRepeating(nameof(Disabler),  Time.deltaTime,1f);
        InvokeRepeating(nameof(TrailEneabler), Time.deltaTime, 0.1f);
    }
    void Update()
    {
        transform.Translate(30f * Time.deltaTime * -Vector3.forward);
    }
    void TrailEneabler()
    {
        if (BulletTrail != null)
        {
            BulletTrail.enabled = true;
        }
    }
    void Disabler()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }
}
