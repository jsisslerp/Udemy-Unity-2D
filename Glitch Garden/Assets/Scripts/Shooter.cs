using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] private GameObject projectile, gun;

	// Use this for initialization
	void Start () {
		
	}

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
