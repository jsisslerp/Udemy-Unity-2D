using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 paddlePos = transform.position;
        paddlePos.x = Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minX, maxX);
        transform.position = paddlePos;
	}
}
