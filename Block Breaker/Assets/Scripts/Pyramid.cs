using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour {
    [SerializeField] AudioClip breakSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyPyramid();
    }

    private void DestroyPyramid()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.AddToScore();
        Destroy(gameObject);
    }
}
