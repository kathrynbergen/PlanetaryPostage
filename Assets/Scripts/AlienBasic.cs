using UnityEngine;

public class AlienBasic : ObstacleObject
{
    public void Start()
    {
        ObstacleSpeed = -2f; // temp - change to GameParameters.AlienBasicSpeed once GameParameters class exists
        isShooter = false;
        base.Start(); 
    }
}