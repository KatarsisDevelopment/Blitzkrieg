using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Enemy : MonoBehaviour
{
    Tank Tank;
    public EnemyType EnemyType;
    public int CurrentHealt;
    GameObject ýnstantinateObject;
    private void Awake()
    {
      ýnstantinateObject = ExplosionEffectPool.instance.GetPooledObject();
    }
    void Start()
    {
        CurrentHealt = EnemyType.Health;
        Tank = FindObjectOfType<Tank>();
        StartCoroutine(Attack());
    }
    void Update()
    {
        transform.LookAt(Tank.transform.position);
        float distanceToPlayer = Vector3.Distance(transform.position, Tank.transform.position);
        if (distanceToPlayer > 15f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Tank.transform.position, 3f * Time.deltaTime);
        }
        if (CurrentHealt <= 0)
        {
            gameObject.SetActive(false);
            CurrentHealt += EnemyType.Health;
            GameObject ýnstantinateObject = GoldPool.goldpool.GetGold();
            if (ýnstantinateObject != null)
            {
                ýnstantinateObject.transform.position = transform.position;
                ýnstantinateObject.SetActive(true);
            }
        }
    }
    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(EnemyType.AttackTime);
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position, transform.forward, out raycastHit, EnemyType.DetectionDistance))
            {
                if (raycastHit.collider.gameObject.layer == 7)
                {
                    Tank.HP -= EnemyType.Damage;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            CurrentHealt -= Tank.Damage;
            if (ýnstantinateObject != null)
            {
                ýnstantinateObject.transform.position = transform.position;
                ýnstantinateObject.SetActive(true);
            }
        }
    }
}
