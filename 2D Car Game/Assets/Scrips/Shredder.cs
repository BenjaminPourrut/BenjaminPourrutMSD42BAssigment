using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    //Reduces enemy health when the enemy collodes with a
    //gameObject that has a DamageDealer component
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        print(otherObject.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);
    }
}
