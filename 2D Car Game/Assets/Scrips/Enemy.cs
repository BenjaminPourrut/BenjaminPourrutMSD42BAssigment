using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float health = 100;

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] float enemyLaserSpeed = 5f;

    //reduce enemy health whenever anmy collodes with a
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
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        //reduce time every frame
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            //enemy shoots
            EnemyFire();
            //reset shotCounter timer
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void EnemyFire()
    {
        GameObject laser = Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity) as GameObject;
        //give the laser a velocity in the y-axis
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyLaserSpeed);
    }
}
