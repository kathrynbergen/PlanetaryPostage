using UnityEngine;

public class Asteroid : ObstacleObject
{
    public void Start()
    {
        ObstacleSpeed = GameParameters.AsteroidSpeed; 
        isShooter = false;
        base.Start(); 
    }
}
