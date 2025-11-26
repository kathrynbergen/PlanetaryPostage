using UnityEngine;

public class AlienShooterPlacer : ObstacleObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilSpawn = 3f; // temp - add to GameParameters class
        maximumSecondsUntilSpawn = 8f; 
    }
}