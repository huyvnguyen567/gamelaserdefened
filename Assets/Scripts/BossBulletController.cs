using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : MonoBehaviour
{
    float maxSpeed = 7f;
    float minSpeed = 5f;
    Vector3 targetPos;
    float speed;
    void Start()
    {
        targetPos = new Vector3(Random.Range(-4f, 4f), -7f, 0f);
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
        float delta = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, delta);
        if (transform.position == targetPos) Destroy(this.gameObject);
    }
}
