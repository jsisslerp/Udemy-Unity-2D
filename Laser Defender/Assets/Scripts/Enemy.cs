
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header("Enemy Stats")]
    [SerializeField] private int scoreValue = 150;
    [SerializeField] private float health = 100;

    [Header("Shooting")]
    [SerializeField] private float shotCounter;
    [SerializeField] private float minTimeBetweenShots = 0.2f;
    [SerializeField] private float maxTimeBetweenShots = 3f;
    [SerializeField] private GameObject enemyLaser;
    [SerializeField] private float projectileSpeed = 8f;

    [Header("Sound Effects")]
    [SerializeField] private GameObject explosionVFX;
    [SerializeField] private float durationOfExplosion = 1f;
    [SerializeField] private AudioClip laserSound;
    [SerializeField] [Range(0, 1)] private float laserSoundVolume = 0.1f;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] [Range(0, 1)] private float deathSoundVolume = 0.5f;

    // Use this for initialization
    void Start () {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }
	
	// Update is called once per frame
	void Update () {
        CountDownAndShoot();
	}

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);

        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
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
            Die();
        }
    }

    private void Die()
    {
        GameSession.Instance.Score += scoreValue;
        Destroy(gameObject);
        TriggerExplosionVFX();
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

    private void TriggerExplosionVFX()
    {
        GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
    }
}
