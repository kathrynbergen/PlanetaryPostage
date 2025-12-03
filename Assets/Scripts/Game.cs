using Unity.VisualScripting;
using UnityEngine;

public class Game : MonoBehaviour
{
    public UI UI;
    public AsteroidPlacer AsteroidPlacer;
    public AlienBasicPlacer AlienBasicPlacer;
    public  AlienShooterPlacer AlienShooterPlacer;
    public void Start()
    {
        // disable player movement
        DisableObstacles();
    }
    public void OnStartLevelOneButtonClicked()
    {
        print("Level One Start");
        AdjustDifficultyToLevelOne();
        StartGame();
    }
    public void OnStartLevelTwoButtonClicked()
    {
        print("Level Two Start");
        AdjustDifficultyToLevelTwo();
        StartGame();
    }
    public void OnStartLevelThreeButtonClicked()
    {
        print("Level Three Start");
        AdjustDifficultyToLevelThree();
        StartGame();
    }

    private void DisableObstacles()
    {
        AsteroidPlacer.IsOkToCreate = false;
        AlienBasicPlacer.IsOkToCreate = false;
        AlienShooterPlacer.IsOkToCreate = false;
    }

    private void EnableObstacles()
    {
        AsteroidPlacer.IsOkToCreate = true;
        AlienBasicPlacer.IsOkToCreate = true;
        AlienShooterPlacer.IsOkToCreate = true;
    }
    private void StartGame()
    {
        UI.StartGame();
        UpdateSpawnRates();
        EnableObstacles();
        // enable player movement
    }

    private void UpdateSpawnRates()
    {
        AsteroidPlacer.UpdateSpawnRates();
        AlienBasicPlacer.UpdateSpawnRates();
        AlienShooterPlacer.UpdateSpawnRates();
    }

    private void AdjustDifficultyToLevelOne()
    {
        //UpdateGameParameters(2f,4f,2f,6f,3f,6f);
        UpdateGameParameters(10f,20f,10f,20f,10f,20f);
    }
    private void AdjustDifficultyToLevelTwo()
    {
        UpdateGameParameters(1f,3f,2f,4f,2f,6f);
    }
    private void AdjustDifficultyToLevelThree()
    {
        //UpdateGameParameters(0.5f,2.5f,1f,3f,1f,4f);
        UpdateGameParameters(0f,1f,0f,1f,0f,1f);
    }

    private void UpdateGameParameters(float asteroidMin, float asteroidMax, float alienBasicMin, float alienBasicMax, float alienShooterMin, float alienShooterMax)
    {
        GameParameters.AsteroidMinimumSecondsUntilSpawn = asteroidMin;
        GameParameters.AsteroidMaximumSecondsUntilSpawn = asteroidMax;
        
        GameParameters.AlienBasicMinimumSecondsUntilSpawn = alienBasicMin;
        GameParameters.AlienBasicMaximumSecondsUntilSpawn = alienBasicMax;

        GameParameters.AlienShooterMinimumSecondsUntilSpawn = alienShooterMin;
        GameParameters.AlienShooterMaximumSecondsUntilSpawn = alienShooterMax;
    }
}
