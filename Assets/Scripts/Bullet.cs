using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = -1.5f;
    private SpriteRenderer BulletSpriteRenderer;

    public void Start()
    {
        BulletSpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(CountdownUntilDestroyedOffScreen());
    }
    public void Update()
    {
        Move(new Vector2(bulletSpeed, 0f));
    }
    private void Move(Vector2 direction)
    {
        float xAmount = direction.x * Mathf.Abs(bulletSpeed) * 5f * Time.deltaTime;
        
        BulletSpriteRenderer.transform.Translate(xAmount, 0f, 0f);
    }
    IEnumerator CountdownUntilDestroyedOffScreen()
    {
        yield return new WaitForSeconds(3f);
        print("destroy!");
        Destroy(this.gameObject);
    }
}
