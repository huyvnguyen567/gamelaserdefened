using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    float fireTime = 0.15f;
    float count = 0f;
    public GameObject bulletPrefab;
    public GameObject healthBar;
    public GameObject healthBarBack;
    float health = 2000;
    public ParticleSystem hitEffect;
    LevelManager levelManager;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        Vector3 pos = new Vector3(0f, 8.7f, 0f);
        Vector3 pos2 = new Vector3(10f, 8.75f, 0f);
        Instantiate(healthBar, pos, Quaternion.identity);
        Instantiate(healthBarBack, pos2, Quaternion.identity);
    }

    void Update()
    {
        count += Time.deltaTime;
        if (count > fireTime)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            count = 0;
        }
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag != "boss")
        {    
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();
            if (damageDealer != null)
            {
                health -= damageDealer.GetDamage();
                if (health <= 0) die();
            }
            HitEffect();
            healthBarChange();
            Destroy(other.gameObject);
        }
    }
    void die()
    {
        Destroy(gameObject);
        scoreKeeper.ModifyScore(100);
        levelManager.LoadGameOver();
    }
    void HitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    void healthBarChange()
    {
        float amountHp = health/2000 * 10;
        if (amountHp < 0) amountHp = 0;
        float delta = 2f * Time.deltaTime;
        Vector3 pos = new Vector3(amountHp, 8.75f, 0f);
        GameObject[] objs = GameObject.FindGameObjectsWithTag("bar");
        for (int i = 0; i < objs.Length; i++)
        {
            Destroy(objs[i].gameObject);
        }
        Instantiate(healthBarBack, pos, Quaternion.identity);
    }
}
