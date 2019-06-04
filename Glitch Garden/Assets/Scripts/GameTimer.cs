using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    [Tooltip("Level timer in seconds")]
    [SerializeField] private float levelTime = 10f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        if (Time.timeSinceLevelLoad >= levelTime)
        {
            Debug.Log("time expired");
        }
	}
}
