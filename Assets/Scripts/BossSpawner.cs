using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    ScoreKeeper scoreKeeper;
    bool isCreated = false;
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    
    void Update()
    {
        if (scoreKeeper.GetScore() >= 500 && !isCreated) {
            Vector3 pos = new Vector3(0f, 15f, 0f);
            Instantiate(bossPrefab, pos, Quaternion.identity);
            isCreated = true;
        }
    }
}
