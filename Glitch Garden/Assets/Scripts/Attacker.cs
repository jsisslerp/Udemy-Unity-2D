using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    private float currentSpeed = 1f;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
	}

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("attacker collision: " + name + " with " + collision.gameObject.name);
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            HealthStatus healthStatus = GetComponent<HealthStatus>();
            if (healthStatus)
            {
                healthStatus.Health -= damageDealer.Damage;
            }
        }
    }
}
