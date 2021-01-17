using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Makes the variable editable from unity
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float health = 100;

    [SerializeField] AudioClip PlayerHealthReduced;
    [SerializeField] [Range(0, 1)] float PlayerHealthReduction = 0.75f;

    [SerializeField] GameObject elliminationVFX;
    [SerializeField] float explosionDuration = 1f;

    float xMin, xMax, yMin, yMax;

    float padding1 = 0.6f;
    float padding2 = 1.0f;
    //Coroutine printCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        MoveBoundaries();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
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

        AudioSource.PlayClipAtPoint(PlayerHealthReduced, Camera.main.transform.position, PlayerHealthReduction);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        AudioSource.PlayClipAtPoint(PlayerHealthReduced, Camera.main.transform.position, PlayerHealthReduction);

        FindObjectOfType<Level>().LoadGameOver();

        //start of the explosion effects
        GameObject explosion = Instantiate(elliminationVFX, transform.position, Quaternion.identity);
        //destruction after a Second (1sec)
        Destroy(explosion, explosionDuration);
    }

    private void MoveBoundaries()
    {
        //According to the camera it will setup the boundaries of movement
        Camera gameCamera = Camera.main;


        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding1;

        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding1;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding2;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 00)).y - padding2;
    }

    private void Move()
    {
        //var is a universal varaible which changes it's type according to value
        //The difference of the Player Ship moves in the x-axis is deltaX
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //newXPosition = current pos in x = difference moved in x-axis
        var newXPos = transform.position.x + deltaX;

        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        transform.position = new Vector2(newXPos,-6);
    }
}