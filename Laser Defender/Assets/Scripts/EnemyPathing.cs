using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    private WaveConfig waveConfig;
    private List<Transform> waypoints;
    private int waypointIndex = 0;

    public WaveConfig WaveConfig
    {
        get
        {
            return waveConfig;
        }

        set
        {
            waveConfig = value;
        }
    }

    // Use this for initialization
    void Start () {
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position == waypoints[waypointIndex].position)
        {
            if (++waypointIndex >= waypoints.Count)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, waveConfig.MoveSpeed * Time.deltaTime);
        }
    }
}
