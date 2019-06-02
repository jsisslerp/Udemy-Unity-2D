using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    [SerializeField] private float speed = 1f;
    private Shooter myShooter;

    public Shooter MyShooter
    {
        get
        {
            return myShooter;
        }

        set
        {
            myShooter = value;
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = GetComponent<DamageDealer>();
        HealthStatus healthStatus = collision.gameObject.GetComponent<HealthStatus>();
        Shooter shooter = collision.gameObject.GetComponent<Shooter>();
        if (damageDealer && healthStatus && shooter != myShooter)
        {
            healthStatus.Health -= damageDealer.Damage;
            if (healthStatus.Health <= 0)
            {
                healthStatus.Destroy();
            }
            Destroy(gameObject);
        }
    }
}
