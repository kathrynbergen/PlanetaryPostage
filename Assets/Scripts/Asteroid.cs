using UnityEngine;

public class Asteroid : ObstacleObject
{
    public float MinimumAsteroidSpawnRate = 1f;
    public float MaximumAsteroidSpawnRate = 3f;
    public void Start()
    {
        ObstacleSpeed = -1f; // temp - change to GameParameters.AsteroidSpeed once GameParameters class exists
        base.Start(); 
    }
}
