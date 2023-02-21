using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinder : MonoBehaviour
{
    float horizontalRange = 3f;
    float verticalRange = 1.5f;
    Vector3 currentWaypoint;
    void Start()
    {
        currentWaypoint = waypointCreate();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaypoint != transform.position)
        {
            FollowPath(currentWaypoint);
        } 
        else
        {
            currentWaypoint = waypointCreate();
        }
    }
    void FollowPath(Vector3 waypoint)
    {
        float delta = 2f * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, waypoint, delta);
    }
    Vector3 waypointCreate()
    {
        Vector3 posNow = new Vector3(0f, 5f, 0f);
        Vector3 pos = posNow + new Vector3(Random.Range(-horizontalRange, horizontalRange), Random.Range(-verticalRange, verticalRange),0f);
        return pos;
    }

}
