using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PersistentGameObjectSingleton<Player>
{
    [Header("Player")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float padding = 1f;
    [SerializeField] private int health = 1000;

    [Header("Projectile")]
    [SerializeField] private GameObject playerLaser;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileFiringPeriod = 0.1f;

    [Header("FX")]
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private float durationOfExplosion = 1f;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] [Range(0, 1)] private float deathSoundVolume = 1f;

    Coroutine firingCoroutine;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    public int Health
    {
        get
        {
            return health;
        }
    }

    // Use this for initialization
    void Start () {
        SetupMoveBoundaries();
    }

    // Update is called once per frame
    void Update () {
        Move();
        Fire();
	}

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private void Move()
    {
        var newPos = transform.position + new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * moveSpeed;

        newPos.x = Mathf.Clamp(newPos.x, xMin, xMax);
        newPos.y = Mathf.Clamp(newPos.y, yMin, yMax);

        transform.position = newPos;
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(playerLaser, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            ProcessHit(damageDealer);
        }
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.Damage;
        damageDealer.Hit();
        if (health <= 0)
        {
            FindObjectOfType<Level>().LoadGameOver();
            Destroy(gameObject);
            TriggerExplosionVFX();
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        }
    }

    private void TriggerExplosionVFX()
    {
        GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
    }
}
