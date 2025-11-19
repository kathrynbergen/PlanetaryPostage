using System;
using System.Collections;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    protected float ObstacleSpeed = -1f;
    private SpriteRenderer ObstacleSpriteRenderer;

    public void Start()
    {
        ObstacleSpriteRenderer = ObstaclePrefab.GetComponent<SpriteRenderer>();
        StartCoroutine(CountdownUntilDestroyedOffScreen());
    }
    public void Update()
    {
        Move(new Vector2(ObstacleSpeed, 0));
    }

    IEnumerator CountdownUntilDestroyedOffScreen()
    {
        yield return new WaitForSeconds(5f / Mathf.Abs(ObstacleSpeed));
        print("destroy!");
        Destroy(ObstaclePrefab);
    }
    private void Move(Vector2 direction)
    {
        float xAmount = direction.x * Mathf.Abs(ObstacleSpeed) * 5f * Time.deltaTime;
        float yAmount = direction.y * Mathf.Abs(ObstacleSpeed) * 5f * Time.deltaTime;
        
        ObstacleSpriteRenderer.transform.Translate(xAmount, yAmount, 0f);
    }
}
