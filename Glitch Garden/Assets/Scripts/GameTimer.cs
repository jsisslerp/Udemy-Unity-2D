using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    [Tooltip("Level timer in seconds")]
    [SerializeField] private float levelTime = 10f;
    private bool timeExpired = false;

    public bool TimeExpired
    {
        get
        {
            return timeExpired;
        }
    }

	void Update () {
        if (!timeExpired)
        {
            GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
            timeExpired = Time.timeSinceLevelLoad >= levelTime;
        }
	}
}
