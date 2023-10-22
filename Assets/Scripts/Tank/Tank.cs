using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Tank : MonoBehaviour
{
    //Uprage
    public GameObject UpragePanel;
    float UpdateTime = 60;
    //ScoreandGold
    public Slider HealthBar;
    ParticleSystem ShootEffect;
    public EnemyInstanter EnemyInstanter;
    public int GoldCount;
    public TextMeshProUGUI GoldText;
    //HP
    public float HP;
    public ParticleSystem  Smoke;
    public GameOverScreen GameOverScreen;
    public float repairTime = 10f;
    //ShootandLook
    GameObject Turret, closestEnemy,FirePos;
    public float detectionRadius = 10f;
    public float ShotTime = 2f;
    LayerMask enemyLayer;
    AudioSource AudioSource;
    public int Damage = 10;
    //Movment
    FixedJoystick FixedJoystick;
    public float Speed = 5f;
    void Start()
    {
        HealthBar.value = 100;
        Turret = transform.GetChild(0).gameObject;
        FirePos = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        ShootEffect = FirePos.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
        StartCoroutine(FindClosestEnemyCoroutine());
        enemyLayer  = LayerMask.GetMask("Enemy");
        FixedJoystick = FindObjectOfType<FixedJoystick>();
        AudioSource = GetComponent<AudioSource>();
        UpragePanel.SetActive(false);
    }
    void Update()
    {
        if (repairTime < 0)
        {
            repairTime = 10;
        }
        //Gold 
        GoldText.text = "" + GoldCount;
        GoldCount = PlayerPrefs.GetInt("Gold",GoldCount);
        //HP
        HealthBar.value = HealthBar.minValue + HP;
        if (HP < HealthBar.maxValue / 2)
        {
            Smoke.Play();
        }
        else
        {
            Smoke.Stop();
        }
        if (HP<=0)
        {
            Smoke.Stop();
            Dead();
            GameOverScreen.GameOver();
        }
        else
        {
            Move();
            Look();
        }
        //Update Screen
        if (FindObjectOfType<GameController>().time >= UpdateTime)
        {
            UpragePanel.SetActive(true);
            UpdateTime *= 2;
            Time.timeScale = 0;
            EnemyInstanter.InstantinateSpeed -= 0.25f;
        }
        //Camera
        Camera.main.transform.position = transform.position + new Vector3(0, 85, -20); 
    }
    public void Repair()
    {
        repairTime -= 1f * Time.deltaTime;
        if (repairTime < 0)
        {
            HP += 10;
            Debug.Log("Repaired");
        }
    }
    public void Look()
    {
        //Look Enemy
        if (closestEnemy != null)
        {
            Vector3 direction = Turret.transform.position - closestEnemy.transform.position;
            direction.y = 0f;
            Quaternion rotation = Quaternion.LookRotation(-direction);
            Turret.transform.rotation = rotation;
        }
    }
    public void Move()
    {
        //Movment
        float hor = FixedJoystick.Horizontal;
        float ver = FixedJoystick.Vertical;
        transform.position += new Vector3(hor, 0, ver) * Time.deltaTime * Speed;
        transform.forward += new Vector3(hor, 0, ver).normalized;
    }
    void Dead()
    {
        if (Camera.main.orthographicSize > 30)
        {
            Camera.main.orthographicSize -= 50f * Time.deltaTime;
        }
    }
    void Shoot()
    {
        GameObject ýnstantinateObject = BulletPool.instance.GetBullet();
        if (ýnstantinateObject!=null)
        {
            ýnstantinateObject.transform.forward = -FirePos.transform.forward;
            ýnstantinateObject.transform.position = FirePos.transform.position;
            ýnstantinateObject.SetActive(true);
            AudioSource.PlayOneShot(AudioSource.clip);
            ShootEffect.Play();
        }
    }
    IEnumerator FindClosestEnemyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(ShotTime);
            if (HP>0)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, enemyLayer);
                float closestDistance = Mathf.Infinity;
                foreach (Collider collider in colliders)
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, collider.transform.position);
                    if (distanceToEnemy < closestDistance)
                    {
                        closestDistance = distanceToEnemy;
                        closestEnemy = collider.gameObject;
                    }
                }
                if (closestEnemy != null)
                {
                    Shoot();
                }
            }
         
        }
    }


}
