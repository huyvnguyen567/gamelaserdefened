using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public int power = 1;
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;

    public GameObject rocket_1;
    public GameObject rocket_2;
    public GameObject rocket_3;

    GameObject Lazer;
    int weaponKind = 1;
    float yOffset = 1.4f;
    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        Lazer = projectilePrefab;
        if(useAI)
        {
            isFiring = true;
            projectileSpeed = 5;
        }
    }

    void Update()
    {
        if (!useAI)
        {
            if (weaponKind == 0)
            {
                projectilePrefab = Lazer;
            }
            else
            {
                if (power == 1 || power == 4) projectilePrefab = rocket_1;
                else if (power == 2 || power == 5) projectilePrefab = rocket_2;
                else projectilePrefab = rocket_3;
            }
        }
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            if (useAI)
            {
                Vector3 vec = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                GameObject instance = Instantiate(projectilePrefab,
                                                    vec,
                                                    Quaternion.identity);

                Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                if (rb != null && useAI)
                {
                    rb.velocity = transform.up * projectileSpeed;
                }
                Destroy(instance, projectileLifetime);
            }
            else if(weaponKind == 0) {
                if (power == 1)
                {
                    Vector3 vec = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z);
                    GameObject instance = Instantiate(projectilePrefab,
                                                    vec,
                                                    Quaternion.identity);
                    Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

                    if (rb != null)
                    {
                        rb.velocity = transform.up * projectileSpeed;
                    }
                    Destroy(instance, projectileLifetime);

                }
                else if (power == 2)
                {
                    Vector3 vec = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z) - new Vector3(0.3f, 0f, 0f);
                    Vector3 vec2 = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z) + new Vector3(0.3f, 0f, 0f);
                    GameObject instance = Instantiate(projectilePrefab, vec, Quaternion.identity);
                    GameObject instance2 = Instantiate(projectilePrefab, vec2, Quaternion.identity);

                    Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb2 = instance2.GetComponent<Rigidbody2D>();


                    if (rb != null)
                    {
                        rb.velocity = transform.up * projectileSpeed;
                        rb2.velocity = transform.up * projectileSpeed;
                    }
                    Destroy(instance, projectileLifetime);
                    Destroy(instance2, projectileLifetime);

                }
                else if (power == 3)
                {
                    Vector3 vec = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z) - new Vector3(0.5f, 0f, 0f);
                    Vector3 vec2 = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z) + new Vector3(0.5f, 0f, 0f);
                    Vector3 vec3 = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z);

                    GameObject instance = Instantiate(projectilePrefab, vec, Quaternion.identity);
                    GameObject instance2 = Instantiate(projectilePrefab, vec2, Quaternion.identity);
                    GameObject instance3 = Instantiate(projectilePrefab, vec3, Quaternion.identity);
                    Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb2 = instance2.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb3 = instance3.GetComponent<Rigidbody2D>();

                    if (rb != null)
                    {
                        rb.velocity = transform.up * projectileSpeed;
                        rb2.velocity = transform.up * projectileSpeed;
                        rb3.velocity = transform.up * projectileSpeed;
                    }
                    Destroy(instance, projectileLifetime);
                    Destroy(instance2, projectileLifetime);
                    Destroy(instance3, projectileLifetime);
                }
                else if (power == 4)
                {
                    Vector3 vec = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z) - new Vector3(0.2f, 0f, 0f);
                    Vector3 vec2 = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z) + new Vector3(0.2f, 0f, 0f);
                    Vector3 vec3 = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z) - new Vector3(0.4f, 0f, 0f);
                    Vector3 vec4 = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z) + new Vector3(0.4f, 0f, 0f);
                    GameObject instance = Instantiate(projectilePrefab, vec, Quaternion.identity);
                    GameObject instance2 = Instantiate(projectilePrefab, vec2, Quaternion.identity);
                    GameObject instance3 = Instantiate(projectilePrefab, vec3, Quaternion.identity);
                    GameObject instance4 = Instantiate(projectilePrefab, vec4, Quaternion.identity);
                    Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb2 = instance2.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb3 = instance3.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb4 = instance4.GetComponent<Rigidbody2D>();

                    if (rb != null)
                    {
                        rb.velocity = transform.up * projectileSpeed;
                        rb2.velocity = transform.up * projectileSpeed;
                        rb3.velocity = transform.up * projectileSpeed;
                        rb4.velocity = transform.up * projectileSpeed;
                    }
                    Destroy(instance, projectileLifetime);
                    Destroy(instance2, projectileLifetime);
                    Destroy(instance3, projectileLifetime);
                    Destroy(instance4, projectileLifetime);
                }
                else
                {
                    Vector3 vec = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z) - new Vector3(0.2f, 0f, 0f);
                    Vector3 vec2 = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z) + new Vector3(0.2f, 0f, 0f);
                    Vector3 vec3 = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z) - new Vector3(0.4f, 0f, 0f);
                    Vector3 vec4 = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z) + new Vector3(0.4f, 0f, 0f);
                    Vector3 vec5 = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z);
                    GameObject instance = Instantiate(projectilePrefab,
                                                    vec,
                                                    Quaternion.identity);
                    GameObject instance2 = Instantiate(projectilePrefab,
                                                    vec2,
                                                    Quaternion.identity);
                    GameObject instance3 = Instantiate(projectilePrefab,
                                                    vec3,
                                                    Quaternion.identity);
                    GameObject instance4 = Instantiate(projectilePrefab,
                                                    vec4,
                                                    Quaternion.identity);
                    GameObject instance5 = Instantiate(projectilePrefab,
                                                    vec5,
                                                    Quaternion.identity);
                    Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb2 = instance2.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb3 = instance3.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb4 = instance4.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb5 = instance5.GetComponent<Rigidbody2D>();


                    if (rb != null)
                    {
                        rb.velocity = transform.up * projectileSpeed;
                        rb2.velocity = transform.up * projectileSpeed;
                        rb3.velocity = transform.up * projectileSpeed;
                        rb4.velocity = transform.up * projectileSpeed;
                        rb5.velocity = transform.up * projectileSpeed;
                    }
                    Destroy(instance, projectileLifetime);
                    Destroy(instance2, projectileLifetime);
                    Destroy(instance3, projectileLifetime);
                    Destroy(instance4, projectileLifetime);
                    Destroy(instance5, projectileLifetime);
                }
            }
            else
            {
                projectileSpeed = 5;
                baseFiringRate = 0.4f;
                if(power <= 3)
                {
                    Vector3 vec = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z);
                    GameObject instance = Instantiate(projectilePrefab,
                                                    vec,
                                                    Quaternion.identity);
                    Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

                    if (rb != null)
                    {
                        rb.velocity = transform.up * projectileSpeed;
                    }
                    Destroy(instance, projectileLifetime);
                }
                else if(power <= 50)
                {
                    Vector3 vec = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z)
                                        + new Vector3(0.4f, 0f, 0f);
                    Vector3 vec2 = new Vector3(this.transform.position.x, this.transform.position.y + yOffset, this.transform.position.z)
                                        + new Vector3(-0.4f, 0f, 0f);
                    GameObject instance = Instantiate(projectilePrefab, vec, Quaternion.identity);
                    GameObject instance2 = Instantiate(projectilePrefab, vec2, Quaternion.identity);
                    Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                    Rigidbody2D rb2 = instance2.GetComponent<Rigidbody2D>();

                    if (rb != null)
                    {
                        rb.velocity = transform.up * projectileSpeed;
                        rb2.velocity = transform.up * projectileSpeed;
                    }
                    Destroy(instance, projectileLifetime);
                    Destroy(instance2, projectileLifetime);
                }
            }
            




            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance,
                                            baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (!useAI)
        {
            if (other.gameObject.tag == "power")
            {
                Destroy(other.gameObject);
                power++;
            }
            if (other.gameObject.tag == "weap1")
            {
                Destroy(other.gameObject);
                weaponKind = 0;
            }
            if (other.gameObject.tag == "weap2")
            {
                Destroy(other.gameObject);
                weaponKind = 1;
            }
        }
    }
}
