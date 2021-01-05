using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    //The enemy sprite it self
    [SerializeField] GameObject enemyPrefab;
    //The path to follow
    [SerializeField] GameObject pathPrefab;
    //Time inbetween enemy spawn generation
    [SerializeField] float timeBetweenSpawns = 0.5f;
    //Random time difference between spawns
    [SerializeField] float spawnRandomfactor = 0.3f;
    //Total number of enemies in wave
    [SerializeField] int numberOfEnemies = 5;
    //Enemy movment speed
    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypointsList()
    {
        //Each wave is able to have different number of waypoints
        var waveWaypoints = new List<Transform>();

        //Access the path prefeb, each waypoints is read and the added to the List waveWaypoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    //calling all Serialized Fields from methods
    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetspawnRandomFactor()
    {
        return spawnRandomfactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
}
