using UnityEngine;

public class Defender : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("defender collision!");
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
