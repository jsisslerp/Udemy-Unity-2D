using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour {
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject pyramidSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    private bool isBreakable;
    [SerializeField] int timesHit = 0;

	// Use this for initialization
	void Start () {
        isBreakable = gameObject.CompareTag("Breakable");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        if (++timesHit >= hitSprites.Length)
        {
            DestroyPyramid();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        if (hitSprites[timesHit] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit];
        }
        else
        {
            Debug.LogError("null sprite, index " + timesHit + " object " + gameObject.name);
        }
    }

    private void DestroyPyramid()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.AddToScore();
        Destroy(gameObject);
        TriggerSparklesVFX();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(pyramidSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
