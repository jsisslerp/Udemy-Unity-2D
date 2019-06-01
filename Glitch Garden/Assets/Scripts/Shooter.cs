using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] private GameObject projectile, gun;
    private AttackerSpawner myLaneSpawner;
    private Animator animator;

	// Use this for initialization
	void Start () {
        foreach(AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            if (Mathf.RoundToInt(spawner.transform.position.y) == Mathf.RoundToInt(transform.position.y))
            {
                myLaneSpawner = spawner;
                break;
            }
        }
        animator = GetComponent<Animator>();
        SetIsAttacking();
	}

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        SetIsAttacking();
    }

    private void SetIsAttacking()
    {
        if (myLaneSpawner && myLaneSpawner.Spawned.Count > 0)
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }

}
