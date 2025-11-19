using UnityEngine;

public class AlienBasic : ObstacleObject
{
    public float MinimumAlienBasicSpawnRate = 2f;
    public float MaximumAlienBasicSpawnRate = 5f;
    public void Start()
    {
        ObstacleSpeed = -2f; // temp - change to GameParameters.AlienBasicSpeed once GameParameters class exists
        base.Start(); 
    }
}