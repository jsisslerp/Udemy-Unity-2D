﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] private Projectile projectile;
    [SerializeField] private GameObject gun;
    
    public void Fire()
    {
        Projectile firedProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        firedProjectile.MyShooter = this;
    }
}
