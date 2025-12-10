using UnityEngine;
using System.Collections;

public class Chuck : MonoBehaviour
{
    public LevelUI LevelUI;
    
    public SpriteRenderer ChuckSpriteRenderer;
    public Sprite NormalSprite;
    public Sprite ParrySprite;
    public Sprite BoostSprite;
    public Sprite PulseSprite;

    //All instances of 5f will be DEFAULT MOVE SPEED, UPDATE IN GAMEPARAMETERS!!!!!!!!!!!!!!!!!!!!
    private float ChuckMoveSpeed = 5f;
    
    //Player States
    private bool isParrying = false;
    private bool isBoosting = false;
    private bool isPulsing = false;
    private bool isShooting = false;
    
    //State Access
    private bool canParry = true;
    private bool canBoost = true;
    
    public void Move(Vector2 direction)
    {
        //CHANGE TO GAMEPARAMETERS.CHUCKMOVESPEED
        float yAmount = direction.y * ChuckMoveSpeed * Time.deltaTime;
        
        ChuckSpriteRenderer.transform.Translate(0, yAmount, 0f);
        //CorgiSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(CorgiSpriteRenderer);
    }

    public void Pulse()
    {
        ChangeToPulseSprite();
        StartCoroutine(PulseTimer());
    }

    IEnumerator PulseTimer()
    {
        isPulsing = true;
        yield return new WaitForSeconds(0.2f);
        isPulsing = false;
        ReturnToNormal();
    }

    public void Parry()
    {
        if (canParry)
        {
            ChangeToParrySprite();
            isParrying = true;
            canBoost = false;
            Debug.Log("Parry!");
            StartCoroutine(ParryTimer());
        }
    }

    IEnumerator ParryTimer()
    {
        //CHNGE TO GAMEPARAMETERS.PARRYTIME
        ChuckMoveSpeed = 3f;
        yield return new WaitForSeconds(0.5f);
        ReturnFromParry();
    }
    
    private void ReturnFromParry()
    {
        ChangeToNormalSprite();
        ChuckMoveSpeed = 5f;
        canBoost = true;
        isParrying = false;
        canParry = false;
        StartCoroutine(ParryCooldown());
    }
    
    IEnumerator ParryCooldown()
    {
        //CHNGE TO GAMEPARAMETERS.PARRYCOOLDOWN
        Debug.Log("Cooldown Start");
        yield return new WaitForSeconds(5f);
        canParry = true;
        Debug.Log("Cooldown Over");
    }
    
    private void ReturnToNormal()
    {
        Debug.Log("Returning to Normal");
        ChuckMoveSpeed = 5f;
        isPulsing = false;
        isParrying = false;
        isBoosting = false;
        isShooting = false;
        ChangeToNormalSprite();
    }

    private void ChangeToParrySprite()
    {
        ChuckSpriteRenderer.sprite = ParrySprite;
    }

    private void ChangeToNormalSprite()
    {
        ChuckSpriteRenderer.sprite = NormalSprite;
    }
    
    private void ChangeToBoostSprite()
    {
        ChuckSpriteRenderer.sprite = BoostSprite;
    }
    
    private void ChangeToPulseSprite()
    {
        ChuckSpriteRenderer.sprite = PulseSprite;
    }

    //Player can boost while boosting, but shouldn't be an issue when we set boost conditions
    public void Boost()
    {
        if (canBoost)
        {
            ChangeToBoostSprite();
            Debug.Log("BOOSTING!");
            isBoosting = true;
            StartCoroutine(BoostTimer());
        }
    }
    
    IEnumerator BoostTimer()
    {
        //CHNGE TO GAMEPARAMETERS.BOOSTTIME
        canParry = false;
        ChuckMoveSpeed = 1.5f;
        yield return new WaitForSeconds(5f);
        canParry = true;
        ReturnToNormal();
    }

    public bool getIsParrying()
    {
        return isParrying;
    }
    
    // when Chuck hits an object
    public void OnTriggerEnter2D(Collider2D other)
    {
        // letter, feather, obstacles (asteroid, spaceships, laser)
        if (other.gameObject.tag == "Letter")
        {
            ScoreKeeper.AddPoint();
            LevelUI.SetScoreText(ScoreKeeper.GetScore());
        }
        
        Destroy(other.gameObject);
    }
}
