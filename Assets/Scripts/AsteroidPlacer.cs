using UnityEngine;

public class AsteroidPlacer : ObstacleObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilSpawn = 1f; // temp - add to GameParameters class
        maximumSecondsUntilSpawn = 3f; 
    }
}
