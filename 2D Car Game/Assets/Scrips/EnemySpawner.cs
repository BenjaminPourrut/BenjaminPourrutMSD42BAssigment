using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //a list of Wave
    [SerializeField] List<WaveConfig> waveConfigsList;

    [SerializeField] bool looping = false;

    //start from 0
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        //when corutine SpawnAllWaves finisghes, check ig looping == true
        while (looping); //while (looping == true)

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
            //spawn the enemy prefab from waveToSpawn
            //at the position of the first waypoint in path
            var newEnemy = Instantiate(
                            waveToSpawn.GetEnemyPrefab(),
                            waveToSpawn.GetWaypointsList()[0].transform.position,
                            Quaternion.identity) as GameObject;

            //adding the wave as a component to the Enemy
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());

        }
    }

    private IEnumerator SpawnAllWaves()
    {
        //access each wave i have in waveConfigsList
        //annd wait for all anamies in that wave to spawn 
        //before looping again
        foreach (WaveConfig currentWave in waveConfigsList)
        {
            //before yieling and returing, spawn all enemies in Wave
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}
