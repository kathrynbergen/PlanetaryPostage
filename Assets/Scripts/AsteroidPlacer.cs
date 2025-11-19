using UnityEngine;

public class AsteroidPlacer : ObstacleObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilSpawn = 2f; // temp - add to GameParameters class
        maximumSecondsUntilSpawn = 4f; 
    }
}
