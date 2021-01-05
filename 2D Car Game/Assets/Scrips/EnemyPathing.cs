using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //A list of type Transform as waypiont are positions in x and y
    [SerializeField] List<Transform> waypointsList;

    [SerializeField] WaveConfig waveConfig;


    //This shows the waypoint of where i want to go next
    int waypointIndex = 0;

    //Start is called before the first frame update
    void Start()
    {
        waypointsList = waveConfig.GetWaypointsList();
        //The position of the Enemy ship is set to the 1st waypoint
        transform.position = waypointsList[waypointIndex].transform.position;


    }


    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }    //This helps for the moving Enemy along a path
    private void EnemyMove()
    {
        if (waypointIndex < waypointsList.Count)
        {
            //Set the targetPosition to the next waypoint Position
            //TargetPosition: where we wish to go
            var targetPosition = waypointsList[waypointIndex].transform.position;

            targetPosition.z = 0f;
            //enemyMovment per frame
            var enemyMovment = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;

            //From current position it gets moved, to target position, at enemyMovement speed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovment);

            //Check if we reached out targetPosition
            if (transform.position == targetPosition)
            {
                waypointIndex++;

            }
        }
        //If the enemy has reached the last waypoint
        else
        {
            Destroy(gameObject);
        }
    }
    //Setting up a wave
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
