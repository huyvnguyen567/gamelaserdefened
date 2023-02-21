using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour
{    public GameObject powerUp;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Random.Range(0f, 10f) < 1f ) {
            Vector3 vec = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(Random.Range(-3, 3), 0f, 0f);
            GameObject instance = Instantiate(powerUp, vec, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * -2f;
            }          
        }
    }

}
