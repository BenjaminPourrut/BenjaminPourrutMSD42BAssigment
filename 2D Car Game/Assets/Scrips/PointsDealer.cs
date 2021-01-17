using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsDealer : MonoBehaviour
{
    [SerializeField] int damage = 50;

    //It returns the amount of damage
    public int GetsDamage()
    {
        return damage;
    }

    public void Hits()
    {
        Destroy(gameObject);

    }
}
