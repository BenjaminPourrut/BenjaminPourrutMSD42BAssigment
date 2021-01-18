using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //A list of Wave
    [SerializeField] List<WaveConfig> waveConfigsList;

    [SerializeField] bool looping = false;

    //Start from 0
    int startingWave = 0;

    // Start is being called in advance in the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        //When corutine SpawnAllWaves finishes, check if looping == true ("==" = is equal to)
        while (looping); //While (looping == true)

        StartCoroutine(SpawnAllWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveToSpawn)
    {
        for (int enemyCount = 1; enemyCount <= waveToSpawn.GetNumberOfEnemies(); enemyCount++)
        {
            //Enemy prefab gets spawned from waveToSpawn
            //At the position of the first waypoint in path
            var newEnemy = Instantiate(
                            waveToSpawn.GetEnemyPrefab(),
                            waveToSpawn.GetWaypointsList()[startingWave].transform.position,
                            Quaternion.identity) as GameObject;

            //The wave is being added as a component to the Enemy
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());

        }
    }

    private IEnumerator SpawnAllWaves()
    {
        //I'm accessing each wave in waveConfigsList
        //Then waiting for all enemies in that wave to spawn 
        //Before sent to loop again
        foreach (WaveConfig currentWave in waveConfigsList)
        {
            //Before yieling and returing, All enemies in Wave get spawned
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}
