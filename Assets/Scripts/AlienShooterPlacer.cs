using UnityEngine;

public class AlienShooterPlacer : ObstacleObjectPlacer
{
    public void Start()
    {
        minimumSecondsUntilSpawn = GameParameters.AlienShooterMinimumSecondsUntilSpawn;
        maximumSecondsUntilSpawn = GameParameters.AlienShooterMaximumSecondsUntilSpawn;
    }
    public void UpdateSpawnRates()
    {
        minimumSecondsUntilSpawn = GameParameters.AlienShooterMinimumSecondsUntilSpawn;
        maximumSecondsUntilSpawn = GameParameters.AlienShooterMaximumSecondsUntilSpawn;
    }
}