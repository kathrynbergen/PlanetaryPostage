using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleObject : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    public GameObject BulletPrefab;
    public Bullet Bullet;
    
    protected float ObstacleSpeed = -1f;
    protected bool isShooter = false;
    
    private SpriteRenderer ObstacleSpriteRenderer;
    private bool canMove = true;
    private bool waitingToShoot = false;
    private bool turnedAround = false;

    public void Start()
    {
        ObstacleSpriteRenderer = ObstaclePrefab.GetComponent<SpriteRenderer>();
        StartCoroutine(CountdownUntilDestroyedOffScreen());
    }
    public void Update()
    {
        Move(new Vector2(ObstacleSpeed, 0));
        if (isShooter && !waitingToShoot)
        {
            waitingToShoot = true;
            StartCoroutine(CountdownUntilShooting());
        }
    }

    IEnumerator CountdownUntilShooting()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(PrepareToShoot());
    }

    IEnumerator PrepareToShoot()
    {
        canMove = false;
        print("preparing to shoot");
        yield return new WaitForSeconds(1f);
        Shoot();
        TurnAround();
    }

    private void TurnAround()
    {
        turnedAround = true;
        canMove = true;
    }

    private void Shoot()
    {
        print("SHOOT!!");
        Instantiate(BulletPrefab, transform.position, Quaternion.identity);
    }

    IEnumerator CountdownUntilDestroyedOffScreen()
    {
        yield return new WaitForSeconds(4f / Mathf.Abs(ObstacleSpeed));
        print("destroy!");
        Destroy(gameObject);
    }
    private void Move(Vector2 direction)
    {
        if (!canMove)
            return;
        float xAmount = direction.x * Mathf.Abs(ObstacleSpeed) * 5f * Time.deltaTime;
        if (turnedAround)
            xAmount *= -1f;
        float yAmount = direction.y * Mathf.Abs(ObstacleSpeed) * 5f * Time.deltaTime;
        
        transform.Translate(new Vector3(xAmount, yAmount, 0f));
    }
}
