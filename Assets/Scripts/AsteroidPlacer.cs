using UnityEngine;

public class AsteroidPlacer : ObstacleObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilSpawn = GameParameters.AsteroidMinimumSecondsUntilSpawn; 
        maximumSecondsUntilSpawn = GameParameters.AsteroidMaximumSecondsUntilSpawn; 
    }

    public void UpdateSpawnRates()
    {
        minimumSecondsUntilSpawn = GameParameters.AsteroidMinimumSecondsUntilSpawn;
        maximumSecondsUntilSpawn = GameParameters.AsteroidMaximumSecondsUntilSpawn;
    }
}
