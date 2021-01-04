using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //a list of type Transform as waypiont are positions in x and y
    [SerializeField] List<Transform> waypointsList;

    [SerializeField] WaveConfig waveConfig;


    //shows the waypoint where i want to go next
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypointsList = waveConfig.GetWaypointsList();
        //set the position of the Enemy ship to the 1st waypoint
        transform.position = waypointsList[waypointIndex].transform.position;


    }


    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }    //takes care of moving Enemy along a path
    private void EnemyMove()
    {
        //   0, 1, 2     <    3
        if (waypointIndex < waypointsList.Count)
        {
            //set the targetPosition to the next waypoint Position
            //targetPosition#: where we want to go
            var targetPosition = waypointsList[waypointIndex].transform.position;

            targetPosition.z = 0f;
            //enemyMovment per frame
            var enemyMovment = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;

            //move from current position, to target position, at enemyMovement speed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovment);

            //check if we reached out targetPosition
            if (transform.position == targetPosition)
            {
                waypointIndex++;

            }
        }
        //if enemy reached last waypoint
        else
        {
            Destroy(gameObject);
        }
    }
    //setting up a wave
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
