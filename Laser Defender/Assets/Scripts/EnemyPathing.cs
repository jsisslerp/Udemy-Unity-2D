using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    [SerializeField] WaveConfig waveConfig;
    private List<Transform> waypoints;
    private float moveSpeed = 2f;
    private int waypointIndex = 0;

	// Use this for initialization
	void Start () {
        waypoints = waveConfig.GetWayPoints();
        moveSpeed = waveConfig.MoveSpeed;
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
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);
        }
    }
}
