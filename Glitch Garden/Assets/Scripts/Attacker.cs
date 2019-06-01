using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    private float currentSpeed = 1f;
    private AttackerSpawner spawner;

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
        spawner.Spawned.Remove(this);
    }
}
