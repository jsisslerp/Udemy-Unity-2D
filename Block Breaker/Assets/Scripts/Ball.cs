using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;

    private Vector2 paddleToBallVector;
    private bool hasStarted = false;

	// Use this for initialization
	void Start () {
        paddleToBallVector = transform.position - paddle1.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
}
