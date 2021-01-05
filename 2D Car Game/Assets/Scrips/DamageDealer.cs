using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 50;

    //It returns the amount of damage
    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);

    }
}