using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject powerUp;
    public GameObject weapon_1;
    public GameObject weapon_2;
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(!isPlayer)
        {
            GameObject obj;
            scoreKeeper.ModifyScore(score);
            float ran = Random.Range(0f, 10f);
            if (ran < 5.5f)
            {
                if (ran > 3.5f) obj = powerUp;
                else if (ran > 1.25f) obj = weapon_1;
                else obj = weapon_2;
                Vector3 vec = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(Random.Range(-3, 3), 0f, 0f);
                GameObject instance = Instantiate(obj, vec, Quaternion.identity);
                Rigidbody2D rid = instance.GetComponent<Rigidbody2D>();
                if (rid != null)
                {
                    rid.velocity = transform.up * 2f;
                }
            }
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
    void Update() {
        
    }
}
