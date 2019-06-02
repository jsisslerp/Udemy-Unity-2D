using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    private float currentSpeed = 1f;
    private AttackerSpawner spawner;
    private GameObject currentTarget;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public AttackerSpawner Spawner
    {
        get
        {
            return spawner;
        }

        set
        {
            spawner = value;
        }
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        if (transform.position.x < -1)
        {
            Destroy(gameObject);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void OnDestroy()
    {
        if (spawner)
        {
            spawner.Spawned.Remove(this);
        }
    }

    public void Attack(GameObject target)
    {
        currentTarget = target;
        animator.SetBool("IsAttacking", true);
    }

    public void StrikeCurrentTarget()
    {
        if (currentTarget)
        {
            HealthStatus healthStatus = currentTarget.GetComponent<HealthStatus>();
            DamageDealer damageDealer = GetComponent<DamageDealer>();
            if (healthStatus && damageDealer)
            {
                healthStatus.Health -= damageDealer.Damage;
                if (healthStatus.Health <= 0)
                {
                    healthStatus.Destroy();
                }
            }
        }
        animator.SetBool("IsAttacking", false);
    }
}
