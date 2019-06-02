using UnityEngine;

public class HealthStatus : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] private GameObject onDestroyVFX;

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public void Destroy()
    {
        if (onDestroyVFX)
        {
            Destroy(Instantiate(onDestroyVFX, transform.position, transform.rotation), 2f);
        }

        Destroy(gameObject);
    }
}
