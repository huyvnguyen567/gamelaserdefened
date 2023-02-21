using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    Vector3 pos;
    void Start()
    {
        pos = new Vector3(-10f,0f,0f);
        float delta = 2f * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, pos, delta);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
