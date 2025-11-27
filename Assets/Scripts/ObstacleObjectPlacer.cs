using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPlacer : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    
    public float minimumSecondsUntilSpawn = 1f;
    public float maximumSecondsUntilSpawn = 3f;

    // bottom and top of screen bounds
    private float minimumY = -3.8f; 
    private float maximumY = 3.8f;
    
    public float minSpacing = 5f;
    public float retryOffset = 5f;
    
    private bool isOkToCreate = true;
    private static List<float> occupiedY = new List<float>();

    // Update is called once per frame
    void Update()
    {
        if (isOkToCreate)
        {
            StartCoroutine(CountdownUntilCreation());
        }
    }
    IEnumerator CountdownUntilCreation()
    {
        isOkToCreate = false;
        
        float secondsToWait = Random.Range(minimumSecondsUntilSpawn, maximumSecondsUntilSpawn);
        yield return new WaitForSeconds(secondsToWait);
        
        yield return TryToPlaceObstacle();
        
        isOkToCreate = true;
    }

    IEnumerator TryToPlaceObstacle()
    {
        float chosenY = Random.Range(minimumY, maximumY);
        for (int attempt = 0; attempt < 20; attempt++)
        {
            if (IsValidY(chosenY))
            {
                PlaceObstacle(chosenY);
                yield break;
            }

            chosenY -= retryOffset;

            if (chosenY < minimumY)
                chosenY = maximumY;
        }

        print("All Y positions blocked — delaying placement");
        yield return new WaitForSeconds(1f);
    }
    private bool IsValidY(float newY)
    {
        foreach (float existingY in occupiedY)
        {
            if (Mathf.Abs(existingY - newY) < minSpacing)
                return false;
        }
        return true;
    }
    public void PlaceObstacle(float yLocation)
    {
        GameObject newObstacle = Instantiate(ObstaclePrefab, new Vector2(10,yLocation), Quaternion.identity);
        occupiedY.Add(yLocation);
    }
    public static void RemoveFromListWhenDestroyed(float yLocation)
    {
        for (int i = 0; i < occupiedY.Count; i++)
        {
            if (Mathf.Abs(occupiedY[i] - yLocation) < 0.001f)
            {
                occupiedY.RemoveAt(i);
                return;
            }
        }
    }
}
