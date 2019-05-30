using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private int immunization = 0;
    [SerializeField] private GameObject onDestroyVFX;

    public int Immunization
    {
        get
        {
            return immunization;
        }

        set
        {
            immunization = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            int damage = damageDealer.Damage;

            if (immunization > 0)
            {
                if (immunization < damage)
                {
                    damage -= immunization;
                    immunization = 0;
                }
                else
                {
                    immunization -= damage;
                    damage = 0;
                }
            }

            HealthStatus healthStatus = GetComponent<HealthStatus>();
            if (healthStatus)
            {
                healthStatus.Health -= damage;
                if (healthStatus.Health <= 0)
                {
                    Destroy();
                }
            }
            else if (damage > 0)
            {
                Destroy();
            }
        }
    }

    private void Destroy()
    {
        if (onDestroyVFX)
        {
            Destroy(Instantiate(onDestroyVFX, transform.position, transform.rotation), 2f);
        }

        Destroy(gameObject);
    }
}
