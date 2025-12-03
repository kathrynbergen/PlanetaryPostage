using UnityEngine;

public class AlienBasic : ObstacleObject
{
    public void Start()
    {
        ObstacleSpeed = GameParameters.AlienBasicSpeed; 
        isShooter = false;
        base.Start(); 
    }
}