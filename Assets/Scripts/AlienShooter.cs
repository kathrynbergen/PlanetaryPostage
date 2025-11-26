using UnityEngine;

public class AlienShooter : ObstacleObject
{
    public void Start()
    {
        ObstacleSpeed = -0.5f; // temp - change to GameParameters.AlienBasicSpeed once GameParameters class exists
        isShooter = true;
        base.Start(); 
    }
}