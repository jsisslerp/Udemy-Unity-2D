using UnityEngine;

public class Damageable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            HealthStatus healthStatus = GetComponent<HealthStatus>();
            if (healthStatus)
            {
                healthStatus.Health -= damageDealer.Damage;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
