using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField] private float screenWidthInUnits = 16f;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;

    private GameStatus myGameStatus;
    private Ball myBall;
    
    // Use this for initialization
    void Start () {
        myGameStatus = FindObjectOfType<GameStatus>();
        myBall = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 paddlePos = transform.position;
        paddlePos.x = GetXPos();
        transform.position = paddlePos;
	}

    private float GetXPos()
    {
        if (myGameStatus.AutoPlay)
        {
            return myBall.transform.position.x;
        }
        else
        {
            return Mathf.Clamp(Input.mousePosition.x / Screen.width * screenWidthInUnits, minX, maxX);
        }
    }

}
