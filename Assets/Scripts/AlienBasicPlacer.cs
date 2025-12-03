using UnityEngine;

public class AlienBasicPlacer : ObstacleObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilSpawn = GameParameters.AlienBasicMinimumSecondsUntilSpawn;
        maximumSecondsUntilSpawn = GameParameters.AlienBasicMaximumSecondsUntilSpawn;
    }
    public void UpdateSpawnRates()
    {
        minimumSecondsUntilSpawn = GameParameters.AlienBasicMinimumSecondsUntilSpawn;
        maximumSecondsUntilSpawn = GameParameters.AlienBasicMaximumSecondsUntilSpawn;
    }
}