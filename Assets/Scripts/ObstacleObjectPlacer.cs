using System.Collections;
using UnityEngine;

public class ObstacleObjectPlacer : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    
    public float minimumSecondsUntilSpawn = 1f;
    public float maximumSecondsUntilSpawn = 3f;

    private bool isOkToCreate = true;
    
    private Coroutine spawnCoroutine;

    // Update is called once per frame
    void Update()
    {
        if (isOkToCreate)
        {
            spawnCoroutine = StartCoroutine(CountdownUntilCreation());
        }
    }
    IEnumerator CountdownUntilCreation()
    {
        isOkToCreate = false;
        float secondsToWait = Random.Range(minimumSecondsUntilSpawn, maximumSecondsUntilSpawn);
        yield return new WaitForSeconds(secondsToWait);
        Place();
        isOkToCreate = true;
    }
    public void Place()
    {
        float yLocation = Random.Range(-3.8f, 3.8f);
        Instantiate(ObstaclePrefab, new Vector2(10,yLocation), Quaternion.identity);
    }
}
