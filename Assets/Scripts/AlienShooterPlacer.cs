using UnityEngine;

public class AlienShooterPlacer : ObstacleObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilSpawn = 2f; // temp - add to GameParameters class
        maximumSecondsUntilSpawn = 6f; 
    }
}