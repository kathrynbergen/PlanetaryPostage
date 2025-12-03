using UnityEngine;

public class AlienShooter : ObstacleObject
{
    public void Start()
    {
        ObstacleSpeed = GameParameters.AlienShooterSpeed;
        isShooter = true;
        base.Start(); 
    }
}