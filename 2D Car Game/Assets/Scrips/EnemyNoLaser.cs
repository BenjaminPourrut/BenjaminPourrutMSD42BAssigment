﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNoLaser : MonoBehaviour
{
    [SerializeField] float health = 50;

    //Reduces enemy health when the enemy collodes with a
    //gameObject that has a DamageDealer component
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();

        ProcessHit(dmg);
    }

    private void ProcessHit(DamageDealer dmg)
    {
        health -= dmg.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}