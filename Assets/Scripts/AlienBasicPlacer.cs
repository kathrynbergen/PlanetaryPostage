using UnityEngine;

public class AlienBasicPlacer : ObstacleObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilSpawn = 2f; // temp - add to GameParameters class
        maximumSecondsUntilSpawn = 10f; 
    }
}