using UnityEngine;

public class Asteroid : ObstacleObject
{
    public void Start()
    {
        ObstacleSpeed = -1f; // temp - change to GameParameters.AsteroidSpeed once GameParameters class exists
        isShooter = false;
        base.Start(); 
    }
}
