using UnityEngine;

public class HealthStatus : MonoBehaviour
{
    [SerializeField] int health = 100;

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
}
