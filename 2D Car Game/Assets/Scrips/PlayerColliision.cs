using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliision : MonoBehaviour
{
    [SerializeField] int scoreValue = 5; 

    private void OnTriggerEnter2D(Collider2D otherObsticle)
    {
        if (otherObsticle.gameObject.name != "Player")
        {
            //this will help to not add the amount therfor counteriong the score addition           
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
        }     
    }
    public int GetScoreValue()
    {
        return scoreValue;
    }
}
