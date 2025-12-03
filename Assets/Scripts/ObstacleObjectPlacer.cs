using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPlacer : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    
    public float minimumSecondsUntilSpawn = 1f;
    public float maximumSecondsUntilSpawn = 3f;

    public bool IsOkToCreate = false;
    
    // bottom and top of screen bounds
    private float minimumY = -3.8f; 
    private float maximumY = 3.8f;
    
    
    private static List<float> occupiedY = new List<float>();
    
    private Coroutine spawnCoroutine;

    // Update is called once per frame
    void Update()
    {
        if (IsOkToCreate && spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(CountdownUntilCreation());
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        IsOkToCreate = false;
        
        float secondsToWait = Random.Range(minimumSecondsUntilSpawn, maximumSecondsUntilSpawn);
        yield return new WaitForSeconds(secondsToWait);
        
        yield return TryToPlaceObstacle();
        
        IsOkToCreate = true;
        spawnCoroutine = null;
    }

    IEnumerator TryToPlaceObstacle()
    {
        for (int attempt = 0; attempt < 50; attempt++)
        {
            float chosenY = Random.Range(minimumY, maximumY);
            
            Vector2 boxSize = new Vector2(0.75f, 0.75f); // 1/2 size of obstacle width and height
            Vector2 spawnPosition = new Vector2(10f, chosenY);

            Collider2D hit = Physics2D.OverlapBox(spawnPosition, boxSize, 0f);

            if (hit == null || hit.tag != "Obstacle") // no overlap with another obstacle
            {
                PlaceObstacle(chosenY);
                yield break;
            }
        }

        print("All Y positions blocked — delaying placement");
        yield return new WaitForSeconds(0.1f);
    }

    public void PlaceObstacle(float yLocation)
    {
        GameObject newObstacle = Instantiate(ObstaclePrefab, new Vector2(10,yLocation), Quaternion.identity);
        occupiedY.Add(yLocation);
    }
}
